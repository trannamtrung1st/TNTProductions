using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IBlogPostRepository : IBaseRepository<BlogPost, int>
	{
	}
	
	public partial class BlogPostRepository : BaseRepository<BlogPost, int>, IBlogPostRepository
	{
		public BlogPostRepository() : base()
		{
		}
		
		public BlogPostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPost Add(BlogPost entity)
		{
			entity.Active = true;
			entity = context.BlogPosts.Add(entity);
			return entity;
		}
		
		public override BlogPost Remove(BlogPost entity)
		{
			context.BlogPosts.Attach(entity);
			entity = context.BlogPosts.Remove(entity);
			return entity;
		}
		
		public override BlogPost Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPosts.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BlogPost> RemoveIf(Expression<Func<BlogPost, bool>> expr)
		{
			return context.BlogPosts.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BlogPost> RemoveRange(IEnumerable<BlogPost> list)
		{
			return context.BlogPosts.RemoveRange(list);
		}
		
		public override BlogPost FindById(int key)
		{
			var entity = context.BlogPosts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPost FindActiveById(int key)
		{
			var entity = context.BlogPosts.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPost> FindByIdAsync(int key)
		{
			var entity = await context.BlogPosts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPost> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogPosts.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPost FindByIdInclude<TProperty>(int key, params Expression<Func<BlogPost, TProperty>>[] members)
		{
			IQueryable<BlogPost> dbSet = context.BlogPosts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogPost> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogPost, TProperty>>[] members)
		{
			IQueryable<BlogPost> dbSet = context.BlogPosts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BlogPost Activate(BlogPost entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPost Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPost Deactivate(BlogPost entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPost Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPost> GetActive()
		{
			return context.BlogPosts.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPost> GetActive(Expression<Func<BlogPost, bool>> expr)
		{
			return context.BlogPosts.Where(e => e.Active).Where(expr);
		}
		
		public override BlogPost FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogPost FirstOrDefault(Expression<Func<BlogPost, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogPost> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogPost> FirstOrDefaultAsync(Expression<Func<BlogPost, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogPost SingleOrDefault(Expression<Func<BlogPost, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogPost> SingleOrDefaultAsync(Expression<Func<BlogPost, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogPost Update(BlogPost entity)
		{
			entity = context.BlogPosts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
