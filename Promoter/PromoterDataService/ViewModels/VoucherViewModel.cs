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
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("campaignId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CampaignId { get; set; }
		[JsonProperty("promotionDetailId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("validationRuleId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleId { get; set; }
		[JsonProperty("assetsObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AssetsObject { get; set; }
		[JsonProperty("metadataObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("isGotten", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsGotten { get; set; }
		[JsonProperty("usingTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> UsingTimes { get; set; }
		[JsonProperty("usedTimes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> UsedTimes { get; set; }
		[JsonProperty("deactive", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Deactive { get; set; }
		[JsonProperty("campaign", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CampaignViewModel CampaignVM { get; set; }
		[JsonProperty("promotionDetail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		[JsonProperty("validationRule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		
		public VoucherViewModel(Voucher entity) : this()
		{
			FromEntity(entity);
		}
		
		public VoucherViewModel()
		{
		}
		
	}
}
