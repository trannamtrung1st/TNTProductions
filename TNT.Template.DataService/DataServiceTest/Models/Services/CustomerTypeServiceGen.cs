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

namespace DataServiceTest.Models.Services
{
	public partial interface ICustomerTypeService : IBaseService<CustomerType, int>
	{
	}
	
	public partial class CustomerTypeService : BaseService<CustomerType, int>, ICustomerTypeService
	{
		public CustomerTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerTypeRepository>(uow);
		}
		
	}
}
