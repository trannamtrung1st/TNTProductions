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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("voucher_config_id")]
		public Nullable<int> VoucherConfigID { get; set; }
		[JsonProperty("campaign_id")]
		public Nullable<int> CampaignID { get; set; }
		[JsonProperty("validation_rule_id")]
		public Nullable<int> ValidationRuleID { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("assets_object")]
		public string AssetsObject { get; set; }
		[JsonProperty("metadata_object")]
		public string MetadataObject { get; set; }
		[JsonProperty("is_gotten")]
		public Nullable<bool> IsGotten { get; set; }
		[JsonProperty("using_times")]
		public Nullable<int> UsingTimes { get; set; }
		[JsonProperty("used_times")]
		public Nullable<int> UsedTimes { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("campaign")]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validation_rule")]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("voucher_config")]
		public VoucherConfigViewModel VoucherConfigVM { get; set; }
		[JsonProperty("gift_details")]
		public IEnumerable<GiftDetailViewModel> GiftDetailsVM { get; set; }
		[JsonProperty("promotion_applied_details")]
		public IEnumerable<PromotionAppliedDetailViewModel> PromotionAppliedDetailsVM { get; set; }
		
		public VoucherViewModel(Voucher entity) : this()
		{
			FromEntity(entity);
		}
		
		public VoucherViewModel()
		{
			this.GiftDetailsVM = new HashSet<GiftDetailViewModel>();
			this.PromotionAppliedDetailsVM = new HashSet<PromotionAppliedDetailViewModel>();
		}
		
	}
}
