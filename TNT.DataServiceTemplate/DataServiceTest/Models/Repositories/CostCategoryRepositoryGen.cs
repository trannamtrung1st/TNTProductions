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
	public partial interface ICostCategoryRepository : IBaseRepository<CostCategory, int>
	{
	}
	
	public partial class CostCategoryRepository : BaseRepository<CostCategory, int>, ICostCategoryRepository
	{
		public CostCategoryRepository() : base()
		{
		}
		
		public CostCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CostCategory Add(CostCategory entity)
		{
			entity.Active = true;
			entity = context.CostCategories.Add(entity);
			return entity;
		}
		
		public override CostCategory Remove(CostCategory entity)
		{
			context.CostCategories.Attach(entity);
			entity = context.CostCategories.Remove(entity);
			return entity;
		}
		
		public override CostCategory Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CostCategories.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<CostCategory> RemoveIf(Expression<Func<CostCategory, bool>> expr)
		{
			return context.CostCategories.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<CostCategory> RemoveRange(IEnumerable<CostCategory> list)
		{
			return context.CostCategories.RemoveRange(list);
		}
		
		public override CostCategory FindById(int key)
		{
			var entity = context.CostCategories.FirstOrDefault(
				e => e.CatID == key);
			return entity;
		}
		
		public override CostCategory FindActiveById(int key)
		{
			var entity = context.CostCategories.FirstOrDefault(
				e => e.CatID == key && e.Active);
			return entity;
		}
		
		public override async Task<CostCategory> FindByIdAsync(int key)
		{
			var entity = await context.CostCategories.FirstOrDefaultAsync(
				e => e.CatID == key);
			return entity;
		}
		
		public override async Task<CostCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.CostCategories.FirstOrDefaultAsync(
				e => e.CatID == key && e.Active);
			return entity;
		}
		
		public override CostCategory FindByIdInclude<TProperty>(int key, params Expression<Func<CostCategory, TProperty>>[] members)
		{
			IQueryable<CostCategory> dbSet = context.CostCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CatID == key);
		}
		
		public override async Task<CostCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CostCategory, TProperty>>[] members)
		{
			IQueryable<CostCategory> dbSet = context.CostCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CatID == key);
		}
		
		public override CostCategory Activate(CostCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CostCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CostCategory Deactivate(CostCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CostCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CostCategory> GetActive()
		{
			return context.CostCategories.Where(e => e.Active);
		}
		
		public override IQueryable<CostCategory> GetActive(Expression<Func<CostCategory, bool>> expr)
		{
			return context.CostCategories.Where(e => e.Active).Where(expr);
		}
		
		public override CostCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CostCategory FirstOrDefault(Expression<Func<CostCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CostCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CostCategory> FirstOrDefaultAsync(Expression<Func<CostCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CostCategory SingleOrDefault(Expression<Func<CostCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CostCategory> SingleOrDefaultAsync(Expression<Func<CostCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CostCategory Update(CostCategory entity)
		{
			entity = context.CostCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
