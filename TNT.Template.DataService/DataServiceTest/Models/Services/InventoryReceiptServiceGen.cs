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
	public partial interface IInventoryReceiptService : IBaseService<InventoryReceipt, int>
	{
	}
	
	public partial class InventoryReceiptService : BaseService<InventoryReceipt, int>, IInventoryReceiptService
	{
		public InventoryReceiptService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptRepository>(uow);
		}
		
		public InventoryReceiptService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryReceiptRepository>(context);
		}
		
	}
}
