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
	public partial interface IRoomCategoryService : IBaseService<RoomCategory, int>
	{
	}
	
	public partial class RoomCategoryService : BaseService<RoomCategory, int>, IRoomCategoryService
	{
		public RoomCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoomCategoryRepository>(uow);
		}
		
		public RoomCategoryService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRoomCategoryRepository>(context);
		}
		
	}
}
