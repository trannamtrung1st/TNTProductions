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
	public partial interface IBlogPostCollectionItemMappingRepository : IBaseRepository<BlogPostCollectionItemMapping, int>
	{
	}
	
	public partial class BlogPostCollectionItemMappingRepository : BaseRepository<BlogPostCollectionItemMapping, int>, IBlogPostCollectionItemMappingRepository
	{
		public BlogPostCollectionItemMappingRepository() : base()
		{
		}
		
		public BlogPostCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollectionItemMapping Add(BlogPostCollectionItemMapping entity)
		{
			entity.Active = true;
			entity = context.BlogPostCollectionItemMappings.Add(entity);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping Remove(BlogPostCollectionItemMapping entity)
		{
			context.BlogPostCollectionItemMappings.Attach(entity);
			entity = context.BlogPostCollectionItemMappings.Remove(entity);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPostCollectionItemMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BlogPostCollectionItemMapping> RemoveIf(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return context.BlogPostCollectionItemMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BlogPostCollectionItemMapping> RemoveRange(IEnumerable<BlogPostCollectionItemMapping> list)
		{
			return context.BlogPostCollectionItemMappings.RemoveRange(list);
		}
		
		public override BlogPostCollectionItemMapping FindById(int key)
		{
			var entity = context.BlogPostCollectionItemMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping FindActiveById(int key)
		{
			var entity = context.BlogPostCollectionItemMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await context.BlogPostCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogPostCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping FindByIdInclude<TProperty>(int key, params Expression<Func<BlogPostCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<BlogPostCollectionItemMapping> dbSet = context.BlogPostCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogPostCollectionItemMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogPostCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<BlogPostCollectionItemMapping> dbSet = context.BlogPostCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BlogPostCollectionItemMapping Activate(BlogPostCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollectionItemMapping Deactivate(BlogPostCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollectionItemMapping> GetActive()
		{
			return context.BlogPostCollectionItemMappings.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollectionItemMapping> GetActive(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return context.BlogPostCollectionItemMappings.Where(e => e.Active).Where(expr);
		}
		
		public override BlogPostCollectionItemMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogPostCollectionItemMapping FirstOrDefault(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogPostCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogPostCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogPostCollectionItemMapping SingleOrDefault(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogPostCollectionItemMapping> SingleOrDefaultAsync(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogPostCollectionItemMapping Update(BlogPostCollectionItemMapping entity)
		{
			entity = context.BlogPostCollectionItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
