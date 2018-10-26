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
	public partial class OrderDomain : BaseDomain<Models.Order, OrderViewModel, int, IOrderService>
	{
		public OrderDomain() : base()
		{
		}
		public OrderDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
