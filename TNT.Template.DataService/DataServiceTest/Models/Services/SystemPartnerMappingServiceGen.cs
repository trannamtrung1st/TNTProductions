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
	public partial interface ISystemPartnerMappingService : IBaseService<SystemPartnerMapping, int>
	{
	}
	
	public partial class SystemPartnerMappingService : BaseService<SystemPartnerMapping, int>, ISystemPartnerMappingService
	{
		public SystemPartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISystemPartnerMappingRepository>(uow);
		}
		
		public SystemPartnerMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ISystemPartnerMappingRepository>(context);
		}
		
	}
}
