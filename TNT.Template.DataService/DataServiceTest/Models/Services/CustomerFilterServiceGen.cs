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
	public partial interface ICustomerFilterService : IBaseService<CustomerFilter, int>
	{
	}
	
	public partial class CustomerFilterService : BaseService<CustomerFilter, int>, ICustomerFilterService
	{
		public CustomerFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerFilterRepository>(uow);
		}
		
		public CustomerFilterService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICustomerFilterRepository>(context);
		}
		
	}
}
