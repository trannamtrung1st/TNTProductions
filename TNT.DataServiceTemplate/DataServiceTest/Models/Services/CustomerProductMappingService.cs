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
	public partial interface ICustomerProductMappingService : IBaseService<CustomerProductMapping, CustomerProductMappingViewModel, int>
	{
	}
	
	public partial class CustomerProductMappingService : BaseService, ICustomerProductMappingService
	{
		private ICustomerProductMappingRepository repository;
		
		public CustomerProductMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerProductMappingRepository>(uow);
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
		public CustomerProductMapping Add(CustomerProductMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerProductMapping> AddAsync(CustomerProductMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerProductMapping Update(CustomerProductMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerProductMapping> UpdateAsync(CustomerProductMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerProductMapping Delete(CustomerProductMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerProductMapping> DeleteAsync(CustomerProductMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerProductMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerProductMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerProductMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerProductMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerProductMapping Activate(CustomerProductMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerProductMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CustomerProductMapping Deactivate(CustomerProductMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerProductMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerProductMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerProductMapping> GetActive(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerProductMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerProductMapping FirstOrDefault(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerProductMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerProductMapping> FirstOrDefaultAsync(Expression<Func<CustomerProductMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CustomerProductMappingService()
		{
			repository = G.TContainer.Resolve<ICustomerProductMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerProductMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
