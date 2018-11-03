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
	public partial interface IOrderDetailPromotionMappingService : IBaseService<OrderDetailPromotionMapping, OrderDetailPromotionMappingViewModel, int>
	{
	}
	
	public partial class OrderDetailPromotionMappingService : BaseService<OrderDetailPromotionMapping, OrderDetailPromotionMappingViewModel, int>, IOrderDetailPromotionMappingService
	{
		public OrderDetailPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailPromotionMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderDetailPromotionMappingService()
		{
			repository = G.TContainer.Resolve<IOrderDetailPromotionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderDetailPromotionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
