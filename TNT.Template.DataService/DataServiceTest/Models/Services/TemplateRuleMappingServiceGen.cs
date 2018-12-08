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
	public partial interface ITemplateRuleMappingService : IBaseService<TemplateRuleMapping, int>
	{
	}
	
	public partial class TemplateRuleMappingService : BaseService<TemplateRuleMapping, int>, ITemplateRuleMappingService
	{
		public TemplateRuleMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateRuleMappingRepository>(uow);
		}
		
		public TemplateRuleMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITemplateRuleMappingRepository>(context);
		}
		
	}
}
