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
	
	public partial class CustomerStoreReportMappingService : BaseService<CustomerStoreReportMapping, CustomerStoreReportMappingViewModel, int>, ICustomerStoreReportMappingService
	{
		public CustomerStoreReportMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerStoreReportMappingRepository>(uow);
		}
		
		
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
