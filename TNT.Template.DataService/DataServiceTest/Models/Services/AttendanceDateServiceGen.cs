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
	public partial interface IAttendanceDateService : IBaseService<AttendanceDate, int>
	{
	}
	
	public partial class AttendanceDateService : BaseService<AttendanceDate, int>, IAttendanceDateService
	{
		public AttendanceDateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceDateRepository>(uow);
		}
		
		public AttendanceDateService(DbContext context)
		{
			repository = G.TContainer.Resolve<IAttendanceDateRepository>(context);
		}
		
	}
}
