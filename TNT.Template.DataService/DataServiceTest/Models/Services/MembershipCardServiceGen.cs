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
	public partial interface IMembershipCardService : IBaseService<MembershipCard, int>
	{
	}
	
	public partial class MembershipCardService : BaseService<MembershipCard, int>, IMembershipCardService
	{
		public MembershipCardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardRepository>(uow);
		}
		
		public MembershipCardService(DbContext context)
		{
			repository = G.TContainer.Resolve<IMembershipCardRepository>(context);
		}
		
	}
}
