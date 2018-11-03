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
	public partial interface IAspNetUserClaimService : IBaseService<AspNetUserClaim, AspNetUserClaimViewModel, int>
	{
	}
	
	public partial class AspNetUserClaimService : BaseService<AspNetUserClaim, AspNetUserClaimViewModel, int>, IAspNetUserClaimService
	{
		public AspNetUserClaimService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserClaimRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AspNetUserClaimService()
		{
			repository = G.TContainer.Resolve<IAspNetUserClaimRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserClaimService()
		{
			Dispose(false);
		}
		#endregion
	}
}
