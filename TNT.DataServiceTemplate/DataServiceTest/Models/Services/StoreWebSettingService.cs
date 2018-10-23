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
	public partial interface IStoreWebSettingService : IBaseService<StoreWebSetting, StoreWebSettingViewModel, int>
	{
	}
	
	public partial class StoreWebSettingService : BaseService, IStoreWebSettingService
	{
		private IStoreWebSettingRepository repository;
		
		public StoreWebSettingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebSettingRepository>(uow);
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
		public StoreWebSetting Add(StoreWebSetting entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreWebSetting> AddAsync(StoreWebSetting entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreWebSetting Update(StoreWebSetting entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreWebSetting> UpdateAsync(StoreWebSetting entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreWebSetting Delete(StoreWebSetting entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreWebSetting> DeleteAsync(StoreWebSetting entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreWebSetting Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreWebSetting> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreWebSetting FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreWebSetting> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreWebSetting Activate(StoreWebSetting entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreWebSetting Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreWebSetting Deactivate(StoreWebSetting entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreWebSetting Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreWebSetting> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreWebSetting> GetActive(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreWebSetting FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreWebSetting FirstOrDefault(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreWebSetting> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreWebSetting> FirstOrDefaultAsync(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreWebSettingService()
		{
			repository = G.TContainer.Resolve<IStoreWebSettingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebSettingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
