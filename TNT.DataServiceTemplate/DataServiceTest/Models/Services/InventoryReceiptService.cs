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
	public partial interface IInventoryReceiptService : IBaseService<InventoryReceipt, InventoryReceiptViewModel, int>
	{
	}
	
	public partial class InventoryReceiptService : BaseService<InventoryReceipt, InventoryReceiptViewModel, int>, IInventoryReceiptService
	{
		public InventoryReceiptService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryReceiptService()
		{
			repository = G.TContainer.Resolve<IInventoryReceiptRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryReceiptService()
		{
			Dispose(false);
		}
		#endregion
	}
}
