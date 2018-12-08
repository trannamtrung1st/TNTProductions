using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IPC_StoreFilterRepository : IBaseRepository<PC_StoreFilter, PC_StoreFilterPK>
	{
	}
	
	public partial class PC_StoreFilterRepository : BaseRepository<PC_StoreFilter, PC_StoreFilterPK>, IPC_StoreFilterRepository
	{
		public PC_StoreFilterRepository(DbContext context) : base(context)
		{
		}
		
		public PC_StoreFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PC_StoreFilter FindById(PC_StoreFilterPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.StoreId == key.StoreId && e.ConstraintId == key.ConstraintId);
			return entity;
		}
		
		public override PC_StoreFilter FindActiveById(PC_StoreFilterPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.StoreId == key.StoreId && e.ConstraintId == key.ConstraintId && e.Active);
			return entity;
		}
		
		public override async Task<PC_StoreFilter> FindByIdAsync(PC_StoreFilterPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.StoreId == key.StoreId && e.ConstraintId == key.ConstraintId);
			return entity;
		}
		
		public override async Task<PC_StoreFilter> FindActiveByIdAsync(PC_StoreFilterPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.StoreId == key.StoreId && e.ConstraintId == key.ConstraintId && e.Active);
			return entity;
		}
		
		public override PC_StoreFilter Activate(PC_StoreFilter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PC_StoreFilter Activate(PC_StoreFilterPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PC_StoreFilter Deactivate(PC_StoreFilter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PC_StoreFilter Deactivate(PC_StoreFilterPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PC_StoreFilter> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PC_StoreFilter> GetActive(Expression<Func<PC_StoreFilter, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
