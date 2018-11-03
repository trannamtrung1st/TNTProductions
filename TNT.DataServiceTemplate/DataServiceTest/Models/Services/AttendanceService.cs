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
	public partial interface IAttendanceService : IBaseService<Attendance, AttendanceViewModel, int>
	{
	}
	
	public partial class AttendanceService : BaseService<Attendance, AttendanceViewModel, int>, IAttendanceService
	{
		public AttendanceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AttendanceService()
		{
			repository = G.TContainer.Resolve<IAttendanceRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AttendanceService()
		{
			Dispose(false);
		}
		#endregion
	}
}
