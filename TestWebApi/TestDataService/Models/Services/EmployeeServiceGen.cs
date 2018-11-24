using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TestDataService.Utilities;
using TestDataService.Managers;
using TestDataService.Models.Repositories;
using TestDataService.Global;
using TNT.IoContainer.Wrapper;

namespace TestDataService.Models.Services
{
	public partial interface IEmployeeService : IBaseService<Employee, string>
	{
	}
	
	public partial class EmployeeService : BaseService<Employee, string>, IEmployeeService
	{
		public EmployeeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeRepository>(uow);
		}
		
		public EmployeeService(EmployeeManagerEntities context)
		{
			repository = G.TContainer.Resolve<IEmployeeRepository>(context);
		}
		
	}
}
