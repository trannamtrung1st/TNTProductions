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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("validation_rule_id")]
		public Nullable<int> ValidationRuleId { get; set; }
		[JsonProperty("voucher_config_id")]
		public Nullable<int> VoucherConfigID { get; set; }
		[JsonProperty("voucher_quantity")]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucher_available_quantity")]
		public Nullable<int> VoucherAvailableQuantity { get; set; }
		[JsonProperty("metadata_object")]
		public string MetadataObject { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("validation_rule")]
		public ValidationRuleViewModel ValidationRuleVM { get; set; }
		[JsonProperty("voucher_config")]
		public VoucherConfigViewModel VoucherConfigVM { get; set; }
		[JsonProperty("promotions")]
		public IEnumerable<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("vouchers")]
		public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
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
