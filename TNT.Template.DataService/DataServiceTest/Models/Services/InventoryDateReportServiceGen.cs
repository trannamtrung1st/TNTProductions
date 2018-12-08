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
	public partial interface IInventoryDateReportService : IBaseService<InventoryDateReport, int>
	{
	}
	
	public partial class InventoryDateReportService : BaseService<InventoryDateReport, int>, IInventoryDateReportService
	{
		public InventoryDateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportRepository>(uow);
		}
		
		public InventoryDateReportService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryDateReportRepository>(context);
		}
		
	}
}
