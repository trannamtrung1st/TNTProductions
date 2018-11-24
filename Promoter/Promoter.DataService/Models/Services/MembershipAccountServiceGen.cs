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
	public partial interface IMembershipAccountService : IBaseService<MembershipAccount, int>
	{
	}
	
	public partial class MembershipAccountService : BaseService<MembershipAccount, int>, IMembershipAccountService
	{
		public MembershipAccountService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipAccountRepository>(uow);
		}
		
		public MembershipAccountService(PromoterEntities context)
		{
			repository = G.TContainer.Resolve<IMembershipAccountRepository>(context);
		}
		
	}
}
