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
		public int ID { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("validation_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ValidationRuleId { get; set; }
		[JsonProperty("voucher_config_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherConfigID { get; set; }
		[JsonProperty("voucher_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucher_available_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherAvailableQuantity { get; set; }
		[JsonProperty("metadata_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MetadataObject { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("validation_rule", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("voucher_config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VoucherConfigViewModel VoucherConfigVM { get; set; }
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
