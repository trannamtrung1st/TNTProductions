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
	public partial interface IRoomCategoryPriceGroupMappingService : IBaseService<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>
	{
	}
	
	public partial class RoomCategoryPriceGroupMappingService : BaseService<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>, IRoomCategoryPriceGroupMappingService
	{
		public RoomCategoryPriceGroupMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryPriceGroupMappingRepository>(uow);
		}
		
		public RoomCategoryPriceGroupMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRoomCategoryPriceGroupMappingRepository>(context);
		}
		
	}
}
