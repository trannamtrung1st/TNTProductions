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
	public partial class GiftAppliedDetailDomain : BaseDomain<Models.GiftAppliedDetail, GiftAppliedDetailViewModel, GiftAppliedDetailPK, IGiftAppliedDetailService>
	{
		public GiftAppliedDetailDomain() : base()
		{
		}
		public GiftAppliedDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
