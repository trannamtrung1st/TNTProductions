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
	public partial interface IMembershipCardTypeService : IBaseService<MembershipCardType, MembershipCardTypeViewModel, int>
	{
	}
	
	public partial class MembershipCardTypeService : BaseService<MembershipCardType, MembershipCardTypeViewModel, int>, IMembershipCardTypeService
	{
		public MembershipCardTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMembershipCardTypeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public MembershipCardTypeService()
		{
			repository = G.TContainer.Resolve<IMembershipCardTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MembershipCardTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
