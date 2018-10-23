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
	public partial interface ICustomerTypeService : IBaseService<CustomerType, CustomerTypeViewModel, int>
	{
	}
	
	public partial class CustomerTypeService : BaseService, ICustomerTypeService
	{
		private ICustomerTypeRepository repository;
		
		public CustomerTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerTypeRepository>(uow);
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
		public CustomerType Add(CustomerType entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerType> AddAsync(CustomerType entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerType Update(CustomerType entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerType> UpdateAsync(CustomerType entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerType Delete(CustomerType entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerType> DeleteAsync(CustomerType entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerType Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerType> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerType FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerType> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerType Activate(CustomerType entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerType Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CustomerType Deactivate(CustomerType entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerType Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerType> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerType> GetActive(Expression<Func<CustomerType, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerType FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerType FirstOrDefault(Expression<Func<CustomerType, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerType> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerType> FirstOrDefaultAsync(Expression<Func<CustomerType, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CustomerTypeService()
		{
			repository = G.TContainer.Resolve<ICustomerTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
