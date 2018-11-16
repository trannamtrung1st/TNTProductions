using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class PromotionStoreRuleViewModel: BaseViewModel<PromotionStoreRule>
	{
		[JsonProperty("validation_rule_id")]
		public int ValidationRuleID { get; set; }
		[JsonProperty("store_iid")]
		public int StoreIID { get; set; }
		[JsonProperty("store_sid")]
		public string StoreSID { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("validation_rule")]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		
		public PromotionStoreRuleViewModel(PromotionStoreRule entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionStoreRuleViewModel()
		{
		}
		
	}
}
