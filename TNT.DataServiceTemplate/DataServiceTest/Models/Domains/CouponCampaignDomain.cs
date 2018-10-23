using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class CouponCampaignDomain : BaseDomain<Models.CouponCampaign, CouponCampaignViewModel, int, ICouponCampaignService>
	{
		public CouponCampaignDomain() : base()
		{
		}
		public CouponCampaignDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
