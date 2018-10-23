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
	public partial interface ICustomerStoreReportMappingService : IBaseService<CustomerStoreReportMapping, CustomerStoreReportMappingViewModel, int>
	{
	}
	
	public partial class CustomerStoreReportMappingService : BaseService, ICustomerStoreReportMappingService
	{
		private ICustomerStoreReportMappingRepository repository;
		
		public CustomerStoreReportMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerStoreReportMappingRepository>(uow);
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
		public CustomerStoreReportMapping Add(CustomerStoreReportMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerStoreReportMapping> AddAsync(CustomerStoreReportMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerStoreReportMapping Update(CustomerStoreReportMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerStoreReportMapping> UpdateAsync(CustomerStoreReportMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerStoreReportMapping Delete(CustomerStoreReportMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerStoreReportMapping> DeleteAsync(CustomerStoreReportMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerStoreReportMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerStoreReportMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerStoreReportMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerStoreReportMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerStoreReportMapping Activate(CustomerStoreReportMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerStoreReportMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CustomerStoreReportMapping Deactivate(CustomerStoreReportMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerStoreReportMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerStoreReportMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerStoreReportMapping> GetActive(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerStoreReportMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerStoreReportMapping FirstOrDefault(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerStoreReportMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerStoreReportMapping> FirstOrDefaultAsync(Expression<Func<CustomerStoreReportMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CustomerStoreReportMappingService()
		{
			repository = G.TContainer.Resolve<ICustomerStoreReportMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerStoreReportMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
