using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;

namespace Promoter.DataService.Models.Services
{
	public partial interface IMembershipService : IBaseService<Membership, int>
	{
	}
	
	public partial class MembershipService : BaseService<Membership, int>, IMembershipService
	{
		public MembershipService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipRepository>(uow);
		}
		
		public MembershipService(PromoterEntities context)
		{
			repository = G.TContainer.Resolve<IMembershipRepository>(context);
		}
		
	}
}
