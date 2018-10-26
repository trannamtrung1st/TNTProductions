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
	public partial class OrderItemDomain : BaseDomain<Models.OrderItem, OrderItemViewModel, int, IOrderItemService>
	{
		public OrderItemDomain() : base()
		{
		}
		public OrderItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
