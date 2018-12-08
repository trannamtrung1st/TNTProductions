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
	public partial interface IInventoryTemplateReportService : IBaseService<InventoryTemplateReport, int>
	{
	}
	
	public partial class InventoryTemplateReportService : BaseService<InventoryTemplateReport, int>, IInventoryTemplateReportService
	{
		public InventoryTemplateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryTemplateReportRepository>(uow);
		}
		
		public InventoryTemplateReportService(DbContext context)
		{
			repository = G.TContainer.Resolve<IInventoryTemplateReportRepository>(context);
		}
		
	}
}
