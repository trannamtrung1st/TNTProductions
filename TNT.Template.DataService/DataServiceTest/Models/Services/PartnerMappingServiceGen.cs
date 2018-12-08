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
	public partial interface IPartnerMappingService : IBaseService<PartnerMapping, int>
	{
	}
	
	public partial class PartnerMappingService : BaseService<PartnerMapping, int>, IPartnerMappingService
	{
		public PartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPartnerMappingRepository>(uow);
		}
		
		public PartnerMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPartnerMappingRepository>(context);
		}
		
	}
}
