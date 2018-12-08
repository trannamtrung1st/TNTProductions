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
	public partial interface IDayModeRepository : IBaseRepository<DayMode, int>
	{
	}
	
	public partial class DayModeRepository : BaseRepository<DayMode, int>, IDayModeRepository
	{
		public DayModeRepository(DbContext context) : base(context)
		{
		}
		
		public DayModeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DayMode FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DayMode FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<DayMode> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DayMode> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override DayMode Activate(DayMode entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override DayMode Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override DayMode Deactivate(DayMode entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override DayMode Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<DayMode> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<DayMode> GetActive(Expression<Func<DayMode, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
