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
	public partial class VoucherViewModel: BaseViewModel<Voucher>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("voucher_config_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherConfigID { get; set; }
		[JsonProperty("campaign_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CampaignID { get; set; }
		[JsonProperty("validation_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleID { get; set; }
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("assets_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AssetsObject { get; set; }
		[JsonProperty("metadata_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("is_gotten", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsGotten { get; set; }
		[JsonProperty("using_times", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> UsingTimes { get; set; }
		[JsonProperty("used_times", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> UsedTimes { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("campaign", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotion_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validation_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("voucher_config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VoucherConfigViewModel VoucherConfigVM { get; set; }
		[JsonProperty("promotion_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public VoucherViewModel(Voucher entity) : this()
		{
			FromEntity(entity);
		}
		
		public VoucherViewModel()
		{
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
