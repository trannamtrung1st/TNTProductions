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
	public partial class PromotionDetailDomain : BaseDomain<Models.PromotionDetail, PromotionDetailViewModel, int, IPromotionDetailService>
	{
		public PromotionDetailDomain() : base()
		{
		}
		public PromotionDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
