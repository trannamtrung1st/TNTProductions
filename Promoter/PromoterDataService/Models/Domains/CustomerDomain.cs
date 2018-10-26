using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class CustomerDomain : BaseDomain<Models.Customer, CustomerViewModel, int, ICustomerService>
	{
		public CustomerDomain() : base()
		{
		}
		public CustomerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
