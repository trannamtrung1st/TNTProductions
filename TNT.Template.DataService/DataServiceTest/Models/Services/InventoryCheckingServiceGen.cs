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
	public partial interface IInventoryCheckingService : IBaseService<InventoryChecking, int>
	{
	}
	
	public partial class InventoryCheckingService : BaseService<InventoryChecking, int>, IInventoryCheckingService
	{
		public InventoryCheckingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryCheckingRepository>(uow);
		}
		
		public InventoryCheckingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryCheckingRepository>(context);
		}
		
	}
}
