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
	public partial interface IInventoryDateReportItemService : IBaseService<InventoryDateReportItem, InventoryDateReportItemViewModel, InventoryDateReportItemPK>
	{
	}
	
	public partial class InventoryDateReportItemService : BaseService<InventoryDateReportItem, InventoryDateReportItemViewModel, InventoryDateReportItemPK>, IInventoryDateReportItemService
	{
		public InventoryDateReportItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryDateReportItemService()
		{
			repository = G.TContainer.Resolve<IInventoryDateReportItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryDateReportItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
