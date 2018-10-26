using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class CampaignDomain : BaseDomain<Models.Campaign, CampaignViewModel, int, ICampaignService>
	{
		public CampaignDomain() : base()
		{
		}
		public CampaignDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
