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
	public partial interface IStoreGroupMappingService : IBaseService<StoreGroupMapping, StoreGroupMappingViewModel, int>
	{
	}
	
	public partial class StoreGroupMappingService : BaseService, IStoreGroupMappingService
	{
		private IStoreGroupMappingRepository repository;
		
		public StoreGroupMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreGroupMappingRepository>(uow);
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
		public StoreGroupMapping Add(StoreGroupMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreGroupMapping> AddAsync(StoreGroupMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreGroupMapping Update(StoreGroupMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreGroupMapping> UpdateAsync(StoreGroupMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreGroupMapping Delete(StoreGroupMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreGroupMapping> DeleteAsync(StoreGroupMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreGroupMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreGroupMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreGroupMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreGroupMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreGroupMapping Activate(StoreGroupMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreGroupMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreGroupMapping Deactivate(StoreGroupMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreGroupMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreGroupMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreGroupMapping> GetActive(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreGroupMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreGroupMapping FirstOrDefault(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreGroupMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreGroupMapping> FirstOrDefaultAsync(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreGroupMappingService()
		{
			repository = G.TContainer.Resolve<IStoreGroupMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreGroupMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
