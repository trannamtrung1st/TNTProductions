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
		public CostCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public CostCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CostCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CatID == key);
			return entity;
		}
		
		public override CostCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CatID == key && e.Active);
			return entity;
		}
		
		public override async Task<CostCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CatID == key);
			return entity;
		}
		
		public override async Task<CostCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CatID == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<CostCategory> GetActive(Expression<Func<CostCategory, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
