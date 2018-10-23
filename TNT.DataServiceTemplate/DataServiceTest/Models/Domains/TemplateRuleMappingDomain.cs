using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class TemplateRuleMappingDomain : BaseDomain<Models.TemplateRuleMapping, TemplateRuleMappingViewModel, int, ITemplateRuleMappingService>
	{
		public TemplateRuleMappingDomain() : base()
		{
		}
		public TemplateRuleMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
