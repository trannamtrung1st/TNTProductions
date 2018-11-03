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
	public partial interface ICouponCampaignService : IBaseService<CouponCampaign, CouponCampaignViewModel, int>
	{
	}
	
	public partial class CouponCampaignService : BaseService<CouponCampaign, CouponCampaignViewModel, int>, ICouponCampaignService
	{
		public CouponCampaignService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponCampaignRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CouponCampaignService()
		{
			repository = G.TContainer.Resolve<ICouponCampaignRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponCampaignService()
		{
			Dispose(false);
		}
		#endregion
	}
}
