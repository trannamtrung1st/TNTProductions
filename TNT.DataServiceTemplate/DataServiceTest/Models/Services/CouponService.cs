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
	public partial interface ICouponService : IBaseService<Coupon, CouponViewModel, int>
	{
	}
	
	public partial class CouponService : BaseService<Coupon, CouponViewModel, int>, ICouponService
	{
		public CouponService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CouponService()
		{
			repository = G.TContainer.Resolve<ICouponRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponService()
		{
			Dispose(false);
		}
		#endregion
	}
}
