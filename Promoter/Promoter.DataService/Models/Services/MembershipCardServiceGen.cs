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
	public partial interface IMembershipCardService : IBaseService<MembershipCard, int>
	{
	}
	
	public partial class MembershipCardService : BaseService<MembershipCard, int>, IMembershipCardService
	{
		public MembershipCardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardRepository>(uow);
		}
		
		public MembershipCardService(PromoterEntities context)
		{
			repository = G.TContainer.Resolve<IMembershipCardRepository>(context);
		}
		
	}
}
