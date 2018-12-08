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
	public partial interface IInventoryReceiptItemService : IBaseService<InventoryReceiptItem, InventoryReceiptItemPK>
	{
	}
	
	public partial class InventoryReceiptItemService : BaseService<InventoryReceiptItem, InventoryReceiptItemPK>, IInventoryReceiptItemService
	{
		public InventoryReceiptItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptItemRepository>(uow);
		}
		
		public InventoryReceiptItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryReceiptItemRepository>(context);
		}
		
	}
}
