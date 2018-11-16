using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IOrderService : IBaseService<Order, int>
	{
	}
	
	public partial class OrderService : BaseService<Order, int>, IOrderService
	{
		public OrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderRepository>(uow);
		}
		
	}
}
