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
	public partial interface ICustomerService : IBaseService<Customer, CustomerViewModel, int>
	{
	}
	
	public partial class CustomerService : BaseService, ICustomerService
	{
		private ICustomerRepository repository;
		
		public CustomerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerRepository>(uow);
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
		public Customer Add(Customer entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Customer> AddAsync(Customer entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Customer Update(Customer entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Customer> UpdateAsync(Customer entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Customer Delete(Customer entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Customer> DeleteAsync(Customer entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Customer Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Customer> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Customer FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Customer> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Customer Activate(Customer entity)
		{
			return repository.Activate(entity);
		}
		
		public Customer Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Customer Deactivate(Customer entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Customer Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Customer> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Customer> GetActive(Expression<Func<Customer, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Customer FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Customer FirstOrDefault(Expression<Func<Customer, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Customer> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
