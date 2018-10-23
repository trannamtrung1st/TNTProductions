using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class OrderFeeItemDomain : BaseDomain<Models.OrderFeeItem, OrderFeeItemViewModel, int, IOrderFeeItemService>
	{
		public OrderFeeItemDomain() : base()
		{
		}
		public OrderFeeItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
