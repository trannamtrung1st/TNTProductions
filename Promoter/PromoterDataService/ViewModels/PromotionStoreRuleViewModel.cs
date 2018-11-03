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
		[JsonProperty("validation_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ValidationRuleID { get; set; }
		[JsonProperty("store_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreIID { get; set; }
		[JsonProperty("store_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreSID { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("validation_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
