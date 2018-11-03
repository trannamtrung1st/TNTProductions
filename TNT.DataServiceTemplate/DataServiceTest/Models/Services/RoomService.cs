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
	public partial interface IRoomService : IBaseService<Room, RoomViewModel, int>
	{
	}
	
	public partial class RoomService : BaseService<Room, RoomViewModel, int>, IRoomService
	{
		public RoomService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RoomService()
		{
			repository = G.TContainer.Resolve<IRoomRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RoomService()
		{
			Dispose(false);
		}
		#endregion
	}
}
