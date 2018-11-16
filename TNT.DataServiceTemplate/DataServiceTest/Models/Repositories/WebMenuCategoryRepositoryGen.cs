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
	public partial interface IWebMenuCategoryRepository : IBaseRepository<WebMenuCategory, int>
	{
	}
	
	public partial class WebMenuCategoryRepository : BaseRepository<WebMenuCategory, int>, IWebMenuCategoryRepository
	{
		public WebMenuCategoryRepository() : base()
		{
		}
		
		public WebMenuCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebMenuCategory Add(WebMenuCategory entity)
		{
			
			entity = context.WebMenuCategories.Add(entity);
			return entity;
		}
		
		public override WebMenuCategory Remove(WebMenuCategory entity)
		{
			context.WebMenuCategories.Attach(entity);
			entity = context.WebMenuCategories.Remove(entity);
			return entity;
		}
		
		public override WebMenuCategory Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebMenuCategories.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<WebMenuCategory> RemoveIf(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return context.WebMenuCategories.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<WebMenuCategory> RemoveRange(IEnumerable<WebMenuCategory> list)
		{
			return context.WebMenuCategories.RemoveRange(list);
		}
		
		public override WebMenuCategory FindById(int key)
		{
			var entity = context.WebMenuCategories.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenuCategory FindActiveById(int key)
		{
			var entity = context.WebMenuCategories.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenuCategory> FindByIdAsync(int key)
		{
			var entity = await context.WebMenuCategories.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenuCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebMenuCategories.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenuCategory FindByIdInclude<TProperty>(int key, params Expression<Func<WebMenuCategory, TProperty>>[] members)
		{
			IQueryable<WebMenuCategory> dbSet = context.WebMenuCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebMenuCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebMenuCategory, TProperty>>[] members)
		{
			IQueryable<WebMenuCategory> dbSet = context.WebMenuCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override WebMenuCategory Activate(WebMenuCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Deactivate(WebMenuCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<WebMenuCategory> GetActive()
		{
			return context.WebMenuCategories;
		}
		
		public override IQueryable<WebMenuCategory> GetActive(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return context.WebMenuCategories.Where(expr);
		}
		
		public override WebMenuCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebMenuCategory FirstOrDefault(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebMenuCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebMenuCategory> FirstOrDefaultAsync(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebMenuCategory SingleOrDefault(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebMenuCategory> SingleOrDefaultAsync(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebMenuCategory Update(WebMenuCategory entity)
		{
			entity = context.WebMenuCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
