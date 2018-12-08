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
	public partial interface IPC_ProductFilterRepository : IBaseRepository<PC_ProductFilter, int>
	{
	}
	
	public partial class PC_ProductFilterRepository : BaseRepository<PC_ProductFilter, int>, IPC_ProductFilterRepository
	{
		public PC_ProductFilterRepository(DbContext context) : base(context)
		{
		}
		
		public PC_ProductFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PC_ProductFilter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FilterId == key);
			return entity;
		}
		
		public override PC_ProductFilter FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FilterId == key && e.Active);
			return entity;
		}
		
		public override async Task<PC_ProductFilter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FilterId == key);
			return entity;
		}
		
		public override async Task<PC_ProductFilter> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FilterId == key && e.Active);
			return entity;
		}
		
		public override PC_ProductFilter Activate(PC_ProductFilter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PC_ProductFilter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PC_ProductFilter Deactivate(PC_ProductFilter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PC_ProductFilter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PC_ProductFilter> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PC_ProductFilter> GetActive(Expression<Func<PC_ProductFilter, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
