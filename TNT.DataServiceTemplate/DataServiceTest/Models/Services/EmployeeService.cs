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
	public partial interface IEmployeeService : IBaseService<Employee, EmployeeViewModel, int>
	{
	}
	
	public partial class EmployeeService : BaseService<Employee, EmployeeViewModel, int>, IEmployeeService
	{
		public EmployeeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public EmployeeService()
		{
			repository = G.TContainer.Resolve<IEmployeeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
