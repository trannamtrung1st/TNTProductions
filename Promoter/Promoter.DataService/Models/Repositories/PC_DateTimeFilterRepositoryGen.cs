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
	public partial interface IPC_DateTimeFilterRepository : IBaseRepository<PC_DateTimeFilter, int>
	{
	}
	
	public partial class PC_DateTimeFilterRepository : BaseRepository<PC_DateTimeFilter, int>, IPC_DateTimeFilterRepository
	{
		public PC_DateTimeFilterRepository(DbContext context) : base(context)
		{
		}
		
		public PC_DateTimeFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PC_DateTimeFilter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FilterId == key);
			return entity;
		}
		
		public override PC_DateTimeFilter FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FilterId == key && e.Active);
			return entity;
		}
		
		public override async Task<PC_DateTimeFilter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FilterId == key);
			return entity;
		}
		
		public override async Task<PC_DateTimeFilter> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FilterId == key && e.Active);
			return entity;
		}
		
		public override PC_DateTimeFilter Activate(PC_DateTimeFilter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PC_DateTimeFilter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PC_DateTimeFilter Deactivate(PC_DateTimeFilter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PC_DateTimeFilter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PC_DateTimeFilter> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PC_DateTimeFilter> GetActive(Expression<Func<PC_DateTimeFilter, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
