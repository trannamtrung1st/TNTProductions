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
	public partial interface IEmployeeSkillService : IBaseService<EmployeeSkill, EmployeeSkillPK>
	{
	}
	
	public partial class EmployeeSkillService : BaseService<EmployeeSkill, EmployeeSkillPK>, IEmployeeSkillService
	{
		public EmployeeSkillService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeSkillRepository>(uow);
		}
		
		public EmployeeSkillService(EmployeeManagerEntities context)
		{
			repository = G.TContainer.Resolve<IEmployeeSkillRepository>(context);
		}
		
	}
}
