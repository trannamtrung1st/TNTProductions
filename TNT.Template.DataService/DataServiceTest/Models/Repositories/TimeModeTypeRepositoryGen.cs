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
	public partial interface ITimeModeTypeRepository : IBaseRepository<TimeModeType, int>
	{
	}
	
	public partial class TimeModeTypeRepository : BaseRepository<TimeModeType, int>, ITimeModeTypeRepository
	{
		public TimeModeTypeRepository(DbContext context) : base(context)
		{
		}
		
		public TimeModeTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeModeType FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeModeType FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeModeType> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeModeType> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TimeModeType Activate(TimeModeType entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TimeModeType Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TimeModeType Deactivate(TimeModeType entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TimeModeType Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TimeModeType> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<TimeModeType> GetActive(Expression<Func<TimeModeType, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
