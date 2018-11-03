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
	public partial interface ITemplateRuleMappingService : IBaseService<TemplateRuleMapping, TemplateRuleMappingViewModel, int>
	{
	}
	
	public partial class TemplateRuleMappingService : BaseService<TemplateRuleMapping, TemplateRuleMappingViewModel, int>, ITemplateRuleMappingService
	{
		public TemplateRuleMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateRuleMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TemplateRuleMappingService()
		{
			repository = G.TContainer.Resolve<ITemplateRuleMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TemplateRuleMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
