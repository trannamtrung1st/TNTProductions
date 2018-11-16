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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("banner")]
		public string Banner { get; set; }
		[JsonProperty("validation_rule_id")]
		public Nullable<int> ValidationRuleID { get; set; }
		[JsonProperty("campaign_id")]
		public Nullable<int> CampaignID { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("available_times")]
		public Nullable<int> AvailableTimes { get; set; }
		[JsonProperty("applied_times")]
		public Nullable<int> AppliedTimes { get; set; }
		[JsonProperty("assets_object")]
		public string AssetsObject { get; set; }
		[JsonProperty("metadata_object")]
		public string MetadataObject { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("campaign")]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validation_rule")]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public PromotionViewModel(Promotion entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
