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
	public partial class DateHotelReportDomain : BaseDomain<Models.DateHotelReport, DateHotelReportViewModel, int, IDateHotelReportService>
	{
		public DateHotelReportDomain() : base()
		{
		}
		public DateHotelReportDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
