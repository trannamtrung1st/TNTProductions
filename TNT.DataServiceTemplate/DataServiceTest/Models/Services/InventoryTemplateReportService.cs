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
	public partial interface IInventoryTemplateReportService : IBaseService<InventoryTemplateReport, InventoryTemplateReportViewModel, int>
	{
	}
	
	public partial class InventoryTemplateReportService : BaseService<InventoryTemplateReport, InventoryTemplateReportViewModel, int>, IInventoryTemplateReportService
	{
		public InventoryTemplateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryTemplateReportRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryTemplateReportService()
		{
			repository = G.TContainer.Resolve<IInventoryTemplateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryTemplateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
