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
	public partial interface IStoreWebViewCounterService : IBaseService<StoreWebViewCounter, StoreWebViewCounterViewModel, int>
	{
	}
	
	public partial class StoreWebViewCounterService : BaseService, IStoreWebViewCounterService
	{
		private IStoreWebViewCounterRepository repository;
		
		public StoreWebViewCounterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebViewCounterRepository>(uow);
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
		public StoreWebViewCounter Add(StoreWebViewCounter entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreWebViewCounter> AddAsync(StoreWebViewCounter entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreWebViewCounter Update(StoreWebViewCounter entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreWebViewCounter> UpdateAsync(StoreWebViewCounter entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreWebViewCounter Delete(StoreWebViewCounter entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreWebViewCounter> DeleteAsync(StoreWebViewCounter entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreWebViewCounter Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreWebViewCounter> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreWebViewCounter FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreWebViewCounter> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreWebViewCounter Activate(StoreWebViewCounter entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreWebViewCounter Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreWebViewCounter Deactivate(StoreWebViewCounter entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreWebViewCounter Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreWebViewCounter> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreWebViewCounter> GetActive(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreWebViewCounter FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreWebViewCounter FirstOrDefault(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreWebViewCounter> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreWebViewCounter> FirstOrDefaultAsync(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreWebViewCounterService()
		{
			repository = G.TContainer.Resolve<IStoreWebViewCounterRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebViewCounterService()
		{
			Dispose(false);
		}
		#endregion
	}
}
