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
	public partial class TemplateReportProductItemMappingDomain : BaseDomain<Models.TemplateReportProductItemMapping, TemplateReportProductItemMappingViewModel, int, ITemplateReportProductItemMappingService>
	{
		public TemplateReportProductItemMappingDomain() : base()
		{
		}
		public TemplateReportProductItemMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
