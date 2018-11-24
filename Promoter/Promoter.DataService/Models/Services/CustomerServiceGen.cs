using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;

namespace Promoter.DataService.Models.Services
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
		
		public CustomerService(PromoterEntities context)
		{
			repository = G.TContainer.Resolve<ICustomerRepository>(context);
		}
		
	}
}
