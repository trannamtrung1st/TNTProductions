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
	public partial class PromotionStoreRuleDomain : BaseDomain<Models.PromotionStoreRule, PromotionStoreRuleViewModel, PromotionStoreRulePK, IPromotionStoreRuleService>
	{
		public PromotionStoreRuleDomain() : base()
		{
		}
		public PromotionStoreRuleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
