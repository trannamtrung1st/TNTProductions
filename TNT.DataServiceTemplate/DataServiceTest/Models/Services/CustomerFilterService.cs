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
	public partial interface ICustomerFilterService : IBaseService<CustomerFilter, CustomerFilterViewModel, int>
	{
	}
	
	public partial class CustomerFilterService : BaseService, ICustomerFilterService
	{
		private ICustomerFilterRepository repository;
		
		public CustomerFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerFilterRepository>(uow);
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
		public CustomerFilter Add(CustomerFilter entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerFilter> AddAsync(CustomerFilter entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerFilter Update(CustomerFilter entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerFilter> UpdateAsync(CustomerFilter entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerFilter Delete(CustomerFilter entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerFilter> DeleteAsync(CustomerFilter entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerFilter Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerFilter> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerFilter FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerFilter> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerFilter Activate(CustomerFilter entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerFilter Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CustomerFilter Deactivate(CustomerFilter entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerFilter Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerFilter> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerFilter> GetActive(Expression<Func<CustomerFilter, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerFilter FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerFilter FirstOrDefault(Expression<Func<CustomerFilter, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerFilter> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerFilter> FirstOrDefaultAsync(Expression<Func<CustomerFilter, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CustomerFilterService()
		{
			repository = G.TContainer.Resolve<ICustomerFilterRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerFilterService()
		{
			Dispose(false);
		}
		#endregion
	}
}
