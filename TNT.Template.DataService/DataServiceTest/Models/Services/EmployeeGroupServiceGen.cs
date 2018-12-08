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
	public partial interface IEmployeeGroupService : IBaseService<EmployeeGroup, int>
	{
	}
	
	public partial class EmployeeGroupService : BaseService<EmployeeGroup, int>, IEmployeeGroupService
	{
		public EmployeeGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeGroupRepository>(uow);
		}
		
		public EmployeeGroupService(DbContext context)
		{
			repository = G.TContainer.Resolve<IEmployeeGroupRepository>(context);
		}
		
	}
}
