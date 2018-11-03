using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IOrderFeeItemService : IBaseService<OrderFeeItem, OrderFeeItemViewModel, int>
	{
	}
	
	public partial class OrderFeeItemService : BaseService<OrderFeeItem, OrderFeeItemViewModel, int>, IOrderFeeItemService
	{
		public OrderFeeItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderFeeItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderFeeItemService()
		{
			repository = G.TContainer.Resolve<IOrderFeeItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderFeeItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
