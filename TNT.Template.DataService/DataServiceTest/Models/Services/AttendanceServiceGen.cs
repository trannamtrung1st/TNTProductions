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
	public partial interface IAttendanceService : IBaseService<Attendance, int>
	{
	}
	
	public partial class AttendanceService : BaseService<Attendance, int>, IAttendanceService
	{
		public AttendanceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceRepository>(uow);
		}
		
		public AttendanceService(DbContext context)
		{
			repository = G.TContainer.Resolve<IAttendanceRepository>(context);
		}
		
	}
}
