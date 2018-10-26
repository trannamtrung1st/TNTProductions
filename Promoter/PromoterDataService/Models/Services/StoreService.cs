using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IStoreService : IBaseService<Store, StoreViewModel, int>
	{
	}
	
	public partial class StoreService : BaseService, IStoreService
	{
		private IStoreRepository repository;
		
		public StoreService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreRepository>(uow);
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
		public Store Add(Store entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Store> AddAsync(Store entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Store Update(Store entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Store> UpdateAsync(Store entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Store Delete(Store entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Store> DeleteAsync(Store entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Store Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Store> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Store FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Store> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Store Activate(Store entity)
		{
			return repository.Activate(entity);
		}
		
		public Store Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Store Deactivate(Store entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Store Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Store> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Store> GetActive(Expression<Func<Store, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Store FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Store FirstOrDefault(Expression<Func<Store, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Store> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Store> FirstOrDefaultAsync(Expression<Func<Store, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
