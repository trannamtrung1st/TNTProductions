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
	public partial interface IApplicationService : IBaseService<Application, System.Guid>
	{
	}
	
	public partial class ApplicationService : BaseService<Application, System.Guid>, IApplicationService
	{
		public ApplicationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IApplicationRepository>(uow);
		}
		
		public ApplicationService(DbContext context)
		{
			repository = G.TContainer.Resolve<IApplicationRepository>(context);
		}
		
	}
}
