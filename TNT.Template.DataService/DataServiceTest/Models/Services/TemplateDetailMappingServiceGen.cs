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
	public partial interface ITemplateDetailMappingService : IBaseService<TemplateDetailMapping, int>
	{
	}
	
	public partial class TemplateDetailMappingService : BaseService<TemplateDetailMapping, int>, ITemplateDetailMappingService
	{
		public TemplateDetailMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateDetailMappingRepository>(uow);
		}
		
		public TemplateDetailMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITemplateDetailMappingRepository>(context);
		}
		
	}
}
