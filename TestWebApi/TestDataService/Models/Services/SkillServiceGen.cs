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
	public partial interface ISkillService : IBaseService<Skill, int>
	{
	}
	
	public partial class SkillService : BaseService<Skill, int>, ISkillService
	{
		public SkillService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISkillRepository>(uow);
		}
		
		public SkillService(EmployeeManagerEntities context)
		{
			repository = G.TContainer.Resolve<ISkillRepository>(context);
		}
		
	}
}
