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
	public partial interface IRoomCategoryService : IBaseService<RoomCategory, RoomCategoryViewModel, int>
	{
	}
	
	public partial class RoomCategoryService : BaseService<RoomCategory, RoomCategoryViewModel, int>, IRoomCategoryService
	{
		public RoomCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RoomCategoryService()
		{
			repository = G.TContainer.Resolve<IRoomCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
