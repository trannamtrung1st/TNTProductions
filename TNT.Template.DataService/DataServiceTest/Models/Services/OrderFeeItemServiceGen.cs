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
	public partial interface IOrderFeeItemService : IBaseService<OrderFeeItem, int>
	{
	}
	
	public partial class OrderFeeItemService : BaseService<OrderFeeItem, int>, IOrderFeeItemService
	{
		public OrderFeeItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderFeeItemRepository>(uow);
		}
		
		public OrderFeeItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IOrderFeeItemRepository>(context);
		}
		
	}
}
