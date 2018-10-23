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
	public partial interface IEmployeeInStoreService : IBaseService<EmployeeInStore, EmployeeInStoreViewModel, int>
	{
	}
	
	public partial class EmployeeInStoreService : BaseService, IEmployeeInStoreService
	{
		private IEmployeeInStoreRepository repository;
		
		public EmployeeInStoreService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeInStoreRepository>(uow);
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
		public EmployeeInStore Add(EmployeeInStore entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<EmployeeInStore> AddAsync(EmployeeInStore entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public EmployeeInStore Update(EmployeeInStore entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<EmployeeInStore> UpdateAsync(EmployeeInStore entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public EmployeeInStore Delete(EmployeeInStore entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<EmployeeInStore> DeleteAsync(EmployeeInStore entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public EmployeeInStore Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<EmployeeInStore> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public EmployeeInStore FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<EmployeeInStore> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public EmployeeInStore Activate(EmployeeInStore entity)
		{
			return repository.Activate(entity);
		}
		
		public EmployeeInStore Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public EmployeeInStore Deactivate(EmployeeInStore entity)
		{
			return repository.Deactivate(entity);
		}
		
		public EmployeeInStore Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<EmployeeInStore> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<EmployeeInStore> GetActive(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public EmployeeInStore FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public EmployeeInStore FirstOrDefault(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<EmployeeInStore> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<EmployeeInStore> FirstOrDefaultAsync(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public EmployeeInStoreService()
		{
			repository = G.TContainer.Resolve<IEmployeeInStoreRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeInStoreService()
		{
			Dispose(false);
		}
		#endregion
	}
}
