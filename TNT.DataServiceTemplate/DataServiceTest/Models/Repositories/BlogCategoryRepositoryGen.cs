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
	public partial interface IBlogCategoryRepository : IBaseRepository<BlogCategory, int>
	{
	}
	
	public partial class BlogCategoryRepository : BaseRepository<BlogCategory, int>, IBlogCategoryRepository
	{
		public BlogCategoryRepository() : base()
		{
		}
		
		public BlogCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogCategory Add(BlogCategory entity)
		{
			
			entity = context.BlogCategories.Add(entity);
			return entity;
		}
		
		public override BlogCategory Remove(BlogCategory entity)
		{
			context.BlogCategories.Attach(entity);
			entity = context.BlogCategories.Remove(entity);
			return entity;
		}
		
		public override BlogCategory Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogCategories.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<BlogCategory> RemoveIf(Expression<Func<BlogCategory, bool>> expr)
		{
			return context.BlogCategories.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<BlogCategory> RemoveRange(IEnumerable<BlogCategory> list)
		{
			return context.BlogCategories.RemoveRange(list);
		}
		
		public override BlogCategory FindById(int key)
		{
			var entity = context.BlogCategories.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogCategory FindActiveById(int key)
		{
			var entity = context.BlogCategories.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogCategory> FindByIdAsync(int key)
		{
			var entity = await context.BlogCategories.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogCategories.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogCategory FindByIdInclude<TProperty>(int key, params Expression<Func<BlogCategory, TProperty>>[] members)
		{
			IQueryable<BlogCategory> dbSet = context.BlogCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogCategory, TProperty>>[] members)
		{
			IQueryable<BlogCategory> dbSet = context.BlogCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override BlogCategory Activate(BlogCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BlogCategory Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BlogCategory Deactivate(BlogCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override BlogCategory Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<BlogCategory> GetActive()
		{
			return context.BlogCategories;
		}
		
		public override IQueryable<BlogCategory> GetActive(Expression<Func<BlogCategory, bool>> expr)
		{
			return context.BlogCategories.Where(expr);
		}
		
		public override BlogCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogCategory FirstOrDefault(Expression<Func<BlogCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogCategory> FirstOrDefaultAsync(Expression<Func<BlogCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogCategory SingleOrDefault(Expression<Func<BlogCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogCategory> SingleOrDefaultAsync(Expression<Func<BlogCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogCategory Update(BlogCategory entity)
		{
			entity = context.BlogCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
