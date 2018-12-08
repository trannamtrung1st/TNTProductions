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
	public partial interface IInventoryDateReportItemService : IBaseService<InventoryDateReportItem, InventoryDateReportItemPK>
	{
	}
	
	public partial class InventoryDateReportItemService : BaseService<InventoryDateReportItem, InventoryDateReportItemPK>, IInventoryDateReportItemService
	{
		public InventoryDateReportItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportItemRepository>(uow);
		}
		
		public InventoryDateReportItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryDateReportItemRepository>(context);
		}
		
	}
}
