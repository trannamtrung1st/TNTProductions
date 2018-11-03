using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class PromotionStoreRulePK
	{
		public int ValidationRuleID { get; set; }
		public int StoreIID { get; set; }
	}
	
	public partial class PromotionStoreRule : BaseEntity<PromotionStoreRuleViewModel>
	{
		public override PromotionStoreRuleViewModel ToViewModel()
		{
			return new PromotionStoreRuleViewModel(this);
		}
		
	}
}
