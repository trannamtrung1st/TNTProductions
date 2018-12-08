using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface ICustomerProductMappingService : IBaseService<CustomerProductMapping, int>
	{
	}
	
	public partial class CustomerProductMappingService : BaseService<CustomerProductMapping, int>, ICustomerProductMappingService
	{
		public CustomerProductMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerProductMappingRepository>(uow);
		}
		
		public CustomerProductMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICustomerProductMappingRepository>(context);
		}
		
	}
}
