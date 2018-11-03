using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface ICustomerService : IBaseService<Customer, CustomerViewModel, int>
	{
	}
	
	public partial class CustomerService : BaseService<Customer, CustomerViewModel, int>, ICustomerService
	{
		public CustomerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerRepository>(uow);
		}
		
	}
}
