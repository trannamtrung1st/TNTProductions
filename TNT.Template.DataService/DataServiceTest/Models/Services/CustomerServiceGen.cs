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
	public partial interface ICustomerService : IBaseService<Customer, int>
	{
	}
	
	public partial class CustomerService : BaseService<Customer, int>, ICustomerService
	{
		public CustomerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerRepository>(uow);
		}
		
		public CustomerService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICustomerRepository>(context);
		}
		
	}
}
