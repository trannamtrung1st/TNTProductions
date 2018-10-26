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
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("banner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Banner { get; set; }
		[JsonProperty("validationRuleId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleId { get; set; }
		[JsonProperty("promotionDetailId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("campaignId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CampaignId { get; set; }
		[JsonProperty("availableTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AvailableTimes { get; set; }
		[JsonProperty("appliedTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AppliedTimes { get; set; }
		[JsonProperty("assetsObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AssetsObject { get; set; }
		[JsonProperty("metadataObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("deactive", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Deactive { get; set; }
		[JsonProperty("campaign", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotionDetail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validationRule", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
