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
	public partial interface IStoreWebRouteRepository : IBaseRepository<StoreWebRoute, int>
	{
	}
	
	public partial class StoreWebRouteRepository : BaseRepository<StoreWebRoute, int>, IStoreWebRouteRepository
	{
		public StoreWebRouteRepository(DbContext context) : base(context)
		{
		}
		
		public StoreWebRouteRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebRoute FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebRoute FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebRoute> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebRoute> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebRoute Activate(StoreWebRoute entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebRoute Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebRoute Deactivate(StoreWebRoute entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebRoute Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebRoute> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebRoute> GetActive(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
