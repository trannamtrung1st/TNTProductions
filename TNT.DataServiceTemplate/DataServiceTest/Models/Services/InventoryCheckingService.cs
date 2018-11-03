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
	public partial interface IInventoryCheckingService : IBaseService<InventoryChecking, InventoryCheckingViewModel, int>
	{
	}
	
	public partial class InventoryCheckingService : BaseService<InventoryChecking, InventoryCheckingViewModel, int>, IInventoryCheckingService
	{
		public InventoryCheckingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryCheckingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryCheckingService()
		{
			repository = G.TContainer.Resolve<IInventoryCheckingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryCheckingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
