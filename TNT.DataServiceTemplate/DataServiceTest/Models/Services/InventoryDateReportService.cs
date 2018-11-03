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
	public partial interface IInventoryDateReportService : IBaseService<InventoryDateReport, InventoryDateReportViewModel, int>
	{
	}
	
	public partial class InventoryDateReportService : BaseService<InventoryDateReport, InventoryDateReportViewModel, int>, IInventoryDateReportService
	{
		public InventoryDateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public InventoryDateReportService()
		{
			repository = G.TContainer.Resolve<IInventoryDateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryDateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
