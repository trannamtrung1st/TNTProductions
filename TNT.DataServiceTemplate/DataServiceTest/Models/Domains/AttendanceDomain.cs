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
	public partial class AttendanceDomain : BaseDomain<Models.Attendance, AttendanceViewModel, int, IAttendanceService>
	{
		public AttendanceDomain() : base()
		{
		}
		public AttendanceDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
