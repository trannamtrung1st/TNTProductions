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
	public partial interface ITemplateReportProductItemMappingService : IBaseService<TemplateReportProductItemMapping, int>
	{
	}
	
	public partial class TemplateReportProductItemMappingService : BaseService<TemplateReportProductItemMapping, int>, ITemplateReportProductItemMappingService
	{
		public TemplateReportProductItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateReportProductItemMappingRepository>(uow);
		}
		
		public TemplateReportProductItemMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITemplateReportProductItemMappingRepository>(context);
		}
		
	}
}
