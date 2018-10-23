using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IStoreWebRouteService : IBaseService<StoreWebRoute, StoreWebRouteViewModel, int>
	{
	}
	
	public partial class StoreWebRouteService : BaseService, IStoreWebRouteService
	{
		private IStoreWebRouteRepository repository;
		
		public StoreWebRouteService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebRouteRepository>(uow);
		}
		
		public override bool AutoSave
		{
			get
			{
				return repository.AutoSave;
			}
			set
			{
				repository.AutoSave = value;
			}
		}
		
		#region CRUD Area
		public StoreWebRoute Add(StoreWebRoute entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreWebRoute> AddAsync(StoreWebRoute entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreWebRoute Update(StoreWebRoute entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreWebRoute> UpdateAsync(StoreWebRoute entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreWebRoute Delete(StoreWebRoute entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreWebRoute> DeleteAsync(StoreWebRoute entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreWebRoute Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreWebRoute> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreWebRoute FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreWebRoute> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreWebRoute Activate(StoreWebRoute entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreWebRoute Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreWebRoute Deactivate(StoreWebRoute entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreWebRoute Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreWebRoute> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreWebRoute> GetActive(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreWebRoute FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreWebRoute FirstOrDefault(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreWebRoute> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreWebRoute> FirstOrDefaultAsync(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreWebRouteService()
		{
			repository = G.TContainer.Resolve<IStoreWebRouteRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebRouteService()
		{
			Dispose(false);
		}
		#endregion
	}
}
