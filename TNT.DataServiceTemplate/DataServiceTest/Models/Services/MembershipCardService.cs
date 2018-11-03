using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IMembershipCardService : IBaseService<MembershipCard, MembershipCardViewModel, int>
	{
	}
	
	public partial class MembershipCardService : BaseService<MembershipCard, MembershipCardViewModel, int>, IMembershipCardService
	{
		public MembershipCardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public MembershipCardService()
		{
			repository = G.TContainer.Resolve<IMembershipCardRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MembershipCardService()
		{
			Dispose(false);
		}
		#endregion
	}
}
