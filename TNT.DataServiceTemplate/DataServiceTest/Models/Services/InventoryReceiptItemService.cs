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
	public partial interface IInventoryReceiptItemService : IBaseService<InventoryReceiptItem, InventoryReceiptItemViewModel, InventoryReceiptItemPK>
	{
	}
	
	public partial class InventoryReceiptItemService : BaseService<InventoryReceiptItem, InventoryReceiptItemViewModel, InventoryReceiptItemPK>, IInventoryReceiptItemService
	{
		public InventoryReceiptItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryReceiptItemService()
		{
			repository = G.TContainer.Resolve<IInventoryReceiptItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryReceiptItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
