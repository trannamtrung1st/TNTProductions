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

namespace DataServiceTest.Models.Services
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
