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
	public partial interface ICouponCampaignService : IBaseService<CouponCampaign, int>
	{
	}
	
	public partial class CouponCampaignService : BaseService<CouponCampaign, int>, ICouponCampaignService
	{
		public CouponCampaignService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponCampaignRepository>(uow);
		}
		
		public CouponCampaignService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICouponCampaignRepository>(context);
		}
		
	}
}
