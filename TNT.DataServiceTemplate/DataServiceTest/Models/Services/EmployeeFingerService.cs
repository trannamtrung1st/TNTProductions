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
	public partial interface IEmployeeFingerService : IBaseService<EmployeeFinger, EmployeeFingerViewModel, int>
	{
	}
	
	public partial class EmployeeFingerService : BaseService<EmployeeFinger, EmployeeFingerViewModel, int>, IEmployeeFingerService
	{
		public EmployeeFingerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeFingerRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public EmployeeFingerService()
		{
			repository = G.TContainer.Resolve<IEmployeeFingerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeFingerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
