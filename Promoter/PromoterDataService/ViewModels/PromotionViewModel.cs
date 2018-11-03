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
	public partial class PromotionViewModel: BaseViewModel<Promotion>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("banner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Banner { get; set; }
		[JsonProperty("validation_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleID { get; set; }
		[JsonProperty("campaign_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CampaignID { get; set; }
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("available_times", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AvailableTimes { get; set; }
		[JsonProperty("applied_times", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AppliedTimes { get; set; }
		[JsonProperty("assets_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AssetsObject { get; set; }
		[JsonProperty("metadata_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("campaign", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotion_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validation_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		
		public PromotionViewModel(Promotion entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionViewModel()
		{
		}
		
	}
}
