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
	public partial interface IReportTrackingService : IBaseService<ReportTracking, ReportTrackingViewModel, int>
	{
	}
	
	public partial class ReportTrackingService : BaseService<ReportTracking, ReportTrackingViewModel, int>, IReportTrackingService
	{
		public ReportTrackingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IReportTrackingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ReportTrackingService()
		{
			repository = G.TContainer.Resolve<IReportTrackingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ReportTrackingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
