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
	public partial interface IAttendanceDateService : IBaseService<AttendanceDate, AttendanceDateViewModel, int>
	{
	}
	
	public partial class AttendanceDateService : BaseService<AttendanceDate, AttendanceDateViewModel, int>, IAttendanceDateService
	{
		public AttendanceDateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAttendanceDateRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AttendanceDateService()
		{
			repository = G.TContainer.Resolve<IAttendanceDateRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AttendanceDateService()
		{
			Dispose(false);
		}
		#endregion
	}
}
