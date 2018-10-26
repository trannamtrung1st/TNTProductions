using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class PromotionDetail : BaseEntity<PromotionDetailViewModel>
	{
		public override PromotionDetailViewModel ToViewModel()
		{
			return new PromotionDetailViewModel(this);
		}
		
	}
}
