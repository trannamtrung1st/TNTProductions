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
	public partial interface IBlogPostCollectionRepository : IBaseRepository<BlogPostCollection, int>
	{
	}
	
	public partial class BlogPostCollectionRepository : BaseRepository<BlogPostCollection, int>, IBlogPostCollectionRepository
	{
		public BlogPostCollectionRepository() : base()
		{
		}
		
		public BlogPostCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollection Add(BlogPostCollection entity)
		{
			entity.Active = true;
			entity = context.BlogPostCollections.Add(entity);
			return entity;
		}
		
		public override BlogPostCollection Remove(BlogPostCollection entity)
		{
			context.BlogPostCollections.Attach(entity);
			entity = context.BlogPostCollections.Remove(entity);
			return entity;
		}
		
		public override BlogPostCollection Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPostCollections.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BlogPostCollection> RemoveIf(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return context.BlogPostCollections.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BlogPostCollection> RemoveRange(IEnumerable<BlogPostCollection> list)
		{
			return context.BlogPostCollections.RemoveRange(list);
		}
		
		public override BlogPostCollection FindById(int key)
		{
			var entity = context.BlogPostCollections.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollection FindActiveById(int key)
		{
			var entity = context.BlogPostCollections.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollection> FindByIdAsync(int key)
		{
			var entity = await context.BlogPostCollections.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollection> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogPostCollections.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollection FindByIdInclude<TProperty>(int key, params Expression<Func<BlogPostCollection, TProperty>>[] members)
		{
			IQueryable<BlogPostCollection> dbSet = context.BlogPostCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogPostCollection> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogPostCollection, TProperty>>[] members)
		{
			IQueryable<BlogPostCollection> dbSet = context.BlogPostCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BlogPostCollection Activate(BlogPostCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollection Deactivate(BlogPostCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollection> GetActive()
		{
			return context.BlogPostCollections.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollection> GetActive(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return context.BlogPostCollections.Where(e => e.Active).Where(expr);
		}
		
		public override BlogPostCollection FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogPostCollection FirstOrDefault(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogPostCollection> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogPostCollection> FirstOrDefaultAsync(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogPostCollection SingleOrDefault(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogPostCollection> SingleOrDefaultAsync(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogPostCollection Update(BlogPostCollection entity)
		{
			entity = context.BlogPostCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
