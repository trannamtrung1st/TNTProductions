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
	public partial class CampaignViewModel: BaseViewModel<Campaign>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("validationRuleId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleId { get; set; }
		[JsonProperty("voucherConfig", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VoucherConfig { get; set; }
		[JsonProperty("voucherQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucherAvailableQuantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherAvailableQuantity { get; set; }
		[JsonProperty("metadataObject", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("deactive", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Deactive { get; set; }
		[JsonProperty("validationRule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("promotions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public CampaignViewModel(Campaign entity) : this()
		{
			FromEntity(entity);
		}
		
		public CampaignViewModel()
		{
			this.PromotionsVM = new HashSet<PromotionViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
