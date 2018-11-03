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
	public partial interface IRoomCategoryPriceGroupMappingService : IBaseService<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingViewModel, RoomCategoryPriceGroupMappingPK>
	{
	}
	
	public partial class RoomCategoryPriceGroupMappingService : BaseService<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingViewModel, RoomCategoryPriceGroupMappingPK>, IRoomCategoryPriceGroupMappingService
	{
		public RoomCategoryPriceGroupMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryPriceGroupMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RoomCategoryPriceGroupMappingService()
		{
			repository = G.TContainer.Resolve<IRoomCategoryPriceGroupMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomCategoryPriceGroupMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
