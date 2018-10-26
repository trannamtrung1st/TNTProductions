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
	public partial class PromotionAppliedDetailDomain : BaseDomain<Models.PromotionAppliedDetail, PromotionAppliedDetailViewModel, int, IPromotionAppliedDetailService>
	{
		public PromotionAppliedDetailDomain() : base()
		{
		}
		public PromotionAppliedDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
