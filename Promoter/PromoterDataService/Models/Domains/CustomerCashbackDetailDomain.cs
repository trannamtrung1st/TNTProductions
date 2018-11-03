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
	public partial class CustomerCashbackDetailDomain : BaseDomain<Models.CustomerCashbackDetail, CustomerCashbackDetailViewModel, int, ICustomerCashbackDetailService>
	{
		public CustomerCashbackDetailDomain() : base()
		{
		}
		public CustomerCashbackDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
