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
	public partial interface IStoreWebRouteModelService : IBaseService<StoreWebRouteModel, StoreWebRouteModelViewModel, int>
	{
	}
	
	public partial class StoreWebRouteModelService : BaseService, IStoreWebRouteModelService
	{
		private IStoreWebRouteModelRepository repository;
		
		public StoreWebRouteModelService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebRouteModelRepository>(uow);
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
		public StoreWebRouteModel Add(StoreWebRouteModel entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreWebRouteModel> AddAsync(StoreWebRouteModel entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreWebRouteModel Update(StoreWebRouteModel entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreWebRouteModel> UpdateAsync(StoreWebRouteModel entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreWebRouteModel Delete(StoreWebRouteModel entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreWebRouteModel> DeleteAsync(StoreWebRouteModel entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreWebRouteModel Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreWebRouteModel> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreWebRouteModel FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreWebRouteModel> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreWebRouteModel Activate(StoreWebRouteModel entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreWebRouteModel Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreWebRouteModel Deactivate(StoreWebRouteModel entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreWebRouteModel Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreWebRouteModel> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreWebRouteModel> GetActive(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreWebRouteModel FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreWebRouteModel FirstOrDefault(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreWebRouteModel> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreWebRouteModel> FirstOrDefaultAsync(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreWebRouteModelService()
		{
			repository = G.TContainer.Resolve<IStoreWebRouteModelRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebRouteModelService()
		{
			Dispose(false);
		}
		#endregion
	}
}
