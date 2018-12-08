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
	public partial interface ITimeFrameRepository : IBaseRepository<TimeFrame, int>
	{
	}
	
	public partial class TimeFrameRepository : BaseRepository<TimeFrame, int>, ITimeFrameRepository
	{
		public TimeFrameRepository(DbContext context) : base(context)
		{
		}
		
		public TimeFrameRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeFrame FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeFrame FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeFrame> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeFrame> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TimeFrame Activate(TimeFrame entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TimeFrame Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TimeFrame Deactivate(TimeFrame entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TimeFrame Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TimeFrame> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<TimeFrame> GetActive(Expression<Func<TimeFrame, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
