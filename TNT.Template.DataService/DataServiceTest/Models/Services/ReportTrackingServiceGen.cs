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
	public partial interface IReportTrackingService : IBaseService<ReportTracking, int>
	{
	}
	
	public partial class ReportTrackingService : BaseService<ReportTracking, int>, IReportTrackingService
	{
		public ReportTrackingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IReportTrackingRepository>(uow);
		}
		
		public ReportTrackingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IReportTrackingRepository>(context);
		}
		
	}
}
