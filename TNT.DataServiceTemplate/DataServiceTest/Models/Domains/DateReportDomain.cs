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
	public partial class DateReportDomain : BaseDomain<Models.DateReport, DateReportViewModel, int, IDateReportService>
	{
		public DateReportDomain() : base()
		{
		}
		public DateReportDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
