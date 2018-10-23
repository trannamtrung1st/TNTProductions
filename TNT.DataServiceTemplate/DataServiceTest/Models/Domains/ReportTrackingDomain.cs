using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class ReportTrackingDomain : BaseDomain<Models.ReportTracking, ReportTrackingViewModel, int, IReportTrackingService>
	{
		public ReportTrackingDomain() : base()
		{
		}
		public ReportTrackingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
