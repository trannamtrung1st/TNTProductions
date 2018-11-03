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
	public partial interface ICouponProviderService : IBaseService<CouponProvider, CouponProviderViewModel, int>
	{
	}
	
	public partial class CouponProviderService : BaseService<CouponProvider, CouponProviderViewModel, int>, ICouponProviderService
	{
		public CouponProviderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponProviderRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CouponProviderService()
		{
			repository = G.TContainer.Resolve<ICouponProviderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponProviderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
