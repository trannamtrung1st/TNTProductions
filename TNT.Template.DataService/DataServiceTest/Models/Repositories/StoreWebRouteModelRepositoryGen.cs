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
	public partial interface IStoreWebRouteModelRepository : IBaseRepository<StoreWebRouteModel, int>
	{
	}
	
	public partial class StoreWebRouteModelRepository : BaseRepository<StoreWebRouteModel, int>, IStoreWebRouteModelRepository
	{
		public StoreWebRouteModelRepository(DbContext context) : base(context)
		{
		}
		
		public StoreWebRouteModelRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebRouteModel FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebRouteModel FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebRouteModel Activate(StoreWebRouteModel entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebRouteModel Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebRouteModel Deactivate(StoreWebRouteModel entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebRouteModel Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebRouteModel> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebRouteModel> GetActive(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
