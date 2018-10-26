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
	public partial class PromotionDomain : BaseDomain<Models.Promotion, PromotionViewModel, int, IPromotionService>
	{
		public PromotionDomain() : base()
		{
		}
		public PromotionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
