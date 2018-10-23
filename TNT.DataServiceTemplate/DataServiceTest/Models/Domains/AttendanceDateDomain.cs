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
	public partial class AttendanceDateDomain : BaseDomain<Models.AttendanceDate, AttendanceDateViewModel, int, IAttendanceDateService>
	{
		public AttendanceDateDomain() : base()
		{
		}
		public AttendanceDateDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
