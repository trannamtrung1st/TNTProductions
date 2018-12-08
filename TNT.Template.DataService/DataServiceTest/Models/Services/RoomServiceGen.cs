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
	public partial interface IRoomService : IBaseService<Room, int>
	{
	}
	
	public partial class RoomService : BaseService<Room, int>, IRoomService
	{
		public RoomService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomRepository>(uow);
		}
		
		public RoomService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRoomRepository>(context);
		}
		
	}
}
