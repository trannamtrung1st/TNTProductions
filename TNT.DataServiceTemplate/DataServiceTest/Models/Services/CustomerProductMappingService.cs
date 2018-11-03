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
	
	public partial class CustomerProductMappingService : BaseService<CustomerProductMapping, CustomerProductMappingViewModel, int>, ICustomerProductMappingService
	{
		public CustomerProductMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerProductMappingRepository>(uow);
		}
		
		
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
