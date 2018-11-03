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
	public partial interface IInventoryCheckingItemService : IBaseService<InventoryCheckingItem, InventoryCheckingItemViewModel, int>
	{
	}
	
	public partial class InventoryCheckingItemService : BaseService<InventoryCheckingItem, InventoryCheckingItemViewModel, int>, IInventoryCheckingItemService
	{
		public InventoryCheckingItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryCheckingItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryCheckingItemService()
		{
			repository = G.TContainer.Resolve<IInventoryCheckingItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryCheckingItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
