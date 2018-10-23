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
	public partial interface IStoreUserService : IBaseService<StoreUser, StoreUserViewModel, StoreUserPK>
	{
	}
	
	public partial class StoreUserService : BaseService, IStoreUserService
	{
		private IStoreUserRepository repository;
		
		public StoreUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreUserRepository>(uow);
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
		public StoreUser Add(StoreUser entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreUser> AddAsync(StoreUser entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreUser Update(StoreUser entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreUser> UpdateAsync(StoreUser entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreUser Delete(StoreUser entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreUser> DeleteAsync(StoreUser entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreUser Delete(StoreUserPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreUser> DeleteAsync(StoreUserPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreUser FindById(StoreUserPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreUser> FindByIdAsync(StoreUserPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreUser Activate(StoreUser entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreUser Activate(StoreUserPK key)
		{
			return repository.Activate(key);
		}
		
		public StoreUser Deactivate(StoreUser entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreUser Deactivate(StoreUserPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreUser> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreUser> GetActive(Expression<Func<StoreUser, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreUser FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreUser FirstOrDefault(Expression<Func<StoreUser, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreUser> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreUser> FirstOrDefaultAsync(Expression<Func<StoreUser, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreUserService()
		{
			repository = G.TContainer.Resolve<IStoreUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
