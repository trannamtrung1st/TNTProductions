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
	public partial interface IPartnerService : IBaseService<Partner, int>
	{
	}
	
	public partial class PartnerService : BaseService<Partner, int>, IPartnerService
	{
		public PartnerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPartnerRepository>(uow);
		}
		
		public PartnerService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPartnerRepository>(context);
		}
		
	}
}
