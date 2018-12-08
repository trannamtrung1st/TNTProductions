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
	public partial interface IEventLocationRepository : IBaseRepository<EventLocation, int>
	{
	}
	
	public partial class EventLocationRepository : BaseRepository<EventLocation, int>, IEventLocationRepository
	{
		public EventLocationRepository(DbContext context) : base(context)
		{
		}
		
		public EventLocationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EventLocation FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.LocationId == key);
			return entity;
		}
		
		public override EventLocation FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.LocationId == key && e.Active);
			return entity;
		}
		
		public override async Task<EventLocation> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.LocationId == key);
			return entity;
		}
		
		public override async Task<EventLocation> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.LocationId == key && e.Active);
			return entity;
		}
		
		public override EventLocation Activate(EventLocation entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EventLocation Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EventLocation Deactivate(EventLocation entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EventLocation Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EventLocation> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<EventLocation> GetActive(Expression<Func<EventLocation, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
