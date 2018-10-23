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
	public partial interface IStoreGroupService : IBaseService<StoreGroup, StoreGroupViewModel, int>
	{
	}
	
	public partial class StoreGroupService : BaseService, IStoreGroupService
	{
		private IStoreGroupRepository repository;
		
		public StoreGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreGroupRepository>(uow);
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
		public StoreGroup Add(StoreGroup entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreGroup> AddAsync(StoreGroup entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreGroup Update(StoreGroup entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreGroup> UpdateAsync(StoreGroup entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreGroup Delete(StoreGroup entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreGroup> DeleteAsync(StoreGroup entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreGroup Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreGroup> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreGroup FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreGroup> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreGroup Activate(StoreGroup entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreGroup Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreGroup Deactivate(StoreGroup entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreGroup Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreGroup> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreGroup> GetActive(Expression<Func<StoreGroup, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreGroup FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreGroup FirstOrDefault(Expression<Func<StoreGroup, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreGroup> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreGroup> FirstOrDefaultAsync(Expression<Func<StoreGroup, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreGroupService()
		{
			repository = G.TContainer.Resolve<IStoreGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
