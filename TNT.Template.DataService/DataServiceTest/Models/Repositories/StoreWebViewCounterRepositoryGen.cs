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
	public partial interface IStoreWebViewCounterRepository : IBaseRepository<StoreWebViewCounter, int>
	{
	}
	
	public partial class StoreWebViewCounterRepository : BaseRepository<StoreWebViewCounter, int>, IStoreWebViewCounterRepository
	{
		public StoreWebViewCounterRepository(DbContext context) : base(context)
		{
		}
		
		public StoreWebViewCounterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebViewCounter FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebViewCounter FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebViewCounter> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebViewCounter> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebViewCounter Activate(StoreWebViewCounter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebViewCounter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebViewCounter Deactivate(StoreWebViewCounter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebViewCounter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebViewCounter> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebViewCounter> GetActive(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
