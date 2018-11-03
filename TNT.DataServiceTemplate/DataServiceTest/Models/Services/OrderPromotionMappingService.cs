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
	public partial interface IOrderPromotionMappingService : IBaseService<OrderPromotionMapping, OrderPromotionMappingViewModel, int>
	{
	}
	
	public partial class OrderPromotionMappingService : BaseService<OrderPromotionMapping, OrderPromotionMappingViewModel, int>, IOrderPromotionMappingService
	{
		public OrderPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderPromotionMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderPromotionMappingService()
		{
			repository = G.TContainer.Resolve<IOrderPromotionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderPromotionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
