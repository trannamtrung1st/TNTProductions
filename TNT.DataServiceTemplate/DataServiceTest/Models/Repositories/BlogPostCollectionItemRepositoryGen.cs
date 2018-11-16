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
	public partial interface IBlogPostCollectionItemRepository : IBaseRepository<BlogPostCollectionItem, int>
	{
	}
	
	public partial class BlogPostCollectionItemRepository : BaseRepository<BlogPostCollectionItem, int>, IBlogPostCollectionItemRepository
	{
		public BlogPostCollectionItemRepository() : base()
		{
		}
		
		public BlogPostCollectionItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollectionItem Add(BlogPostCollectionItem entity)
		{
			entity.Active = true;
			entity = context.BlogPostCollectionItems.Add(entity);
			return entity;
		}
		
		public override BlogPostCollectionItem Remove(BlogPostCollectionItem entity)
		{
			context.BlogPostCollectionItems.Attach(entity);
			entity = context.BlogPostCollectionItems.Remove(entity);
			return entity;
		}
		
		public override BlogPostCollectionItem Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPostCollectionItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BlogPostCollectionItem> RemoveIf(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return context.BlogPostCollectionItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BlogPostCollectionItem> RemoveRange(IEnumerable<BlogPostCollectionItem> list)
		{
			return context.BlogPostCollectionItems.RemoveRange(list);
		}
		
		public override BlogPostCollectionItem FindById(int key)
		{
			var entity = context.BlogPostCollectionItems.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollectionItem FindActiveById(int key)
		{
			var entity = context.BlogPostCollectionItems.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItem> FindByIdAsync(int key)
		{
			var entity = await context.BlogPostCollectionItems.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogPostCollectionItems.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollectionItem FindByIdInclude<TProperty>(int key, params Expression<Func<BlogPostCollectionItem, TProperty>>[] members)
		{
			IQueryable<BlogPostCollectionItem> dbSet = context.BlogPostCollectionItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogPostCollectionItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogPostCollectionItem, TProperty>>[] members)
		{
			IQueryable<BlogPostCollectionItem> dbSet = context.BlogPostCollectionItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BlogPostCollectionItem Activate(BlogPostCollectionItem entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItem Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollectionItem Deactivate(BlogPostCollectionItem entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItem Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollectionItem> GetActive()
		{
			return context.BlogPostCollectionItems.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollectionItem> GetActive(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return context.BlogPostCollectionItems.Where(e => e.Active).Where(expr);
		}
		
		public override BlogPostCollectionItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogPostCollectionItem FirstOrDefault(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogPostCollectionItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogPostCollectionItem> FirstOrDefaultAsync(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogPostCollectionItem SingleOrDefault(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogPostCollectionItem> SingleOrDefaultAsync(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogPostCollectionItem Update(BlogPostCollectionItem entity)
		{
			entity = context.BlogPostCollectionItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
