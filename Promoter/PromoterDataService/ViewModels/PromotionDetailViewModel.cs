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
	public partial class PromotionDetailViewModel: BaseViewModel<PromotionDetail>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("is_discount")]
		public Nullable<bool> IsDiscount { get; set; }
		[JsonProperty("discount_amount")]
		public Nullable<double> DiscountAmount { get; set; }
		[JsonProperty("discount_unit")]
		public Nullable<int> DiscountUnit { get; set; }
		[JsonProperty("is_gift")]
		public Nullable<bool> IsGift { get; set; }
		[JsonProperty("is_cashback")]
		public Nullable<bool> IsCashback { get; set; }
		[JsonProperty("extra_info_object")]
		public string ExtraInfoObject { get; set; }
		[JsonProperty("is_partner")]
		public Nullable<bool> IsPartner { get; set; }
		[JsonProperty("partner_iid")]
		public Nullable<int> PartnerIID { get; set; }
		[JsonProperty("partner_sid")]
		public string PartnerSID { get; set; }
		[JsonProperty("apply_level")]
		public Nullable<int> ApplyLevel { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("partner")]
		public PartnerViewModel PartnerVM { get; set; }
		[JsonProperty("affliator_cashback_details")]
		public IEnumerable<AffliatorCashbackDetailViewModel> AffliatorCashbackDetailsVM { get; set; }
		[JsonProperty("customer_cashback_details")]
		public IEnumerable<CustomerCashbackDetailViewModel> CustomerCashbackDetailsVM { get; set; }
		[JsonProperty("gift_details")]
		public IEnumerable<GiftDetailViewModel> GiftDetailsVM { get; set; }
		[JsonProperty("promotions")]
		public IEnumerable<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("promotion_apply_situations")]
		public IEnumerable<int> ApplySituations { get; set; }
		[JsonProperty("vouchers")]
		public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		[JsonProperty("promotion_types")]
		public IEnumerable<int> PromotionTypes { get; set; }
		
		public PromotionDetailViewModel(PromotionDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionDetailViewModel()
		{
			this.AffliatorCashbackDetailsVM = new HashSet<AffliatorCashbackDetailViewModel>();
			this.CustomerCashbackDetailsVM = new HashSet<CustomerCashbackDetailViewModel>();
			this.GiftDetailsVM = new HashSet<GiftDetailViewModel>();
			this.PromotionsVM = new HashSet<PromotionViewModel>();
			this.ApplySituations = new HashSet<int>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
			this.PromotionTypes = new HashSet<int>();
		}
		
	}
}
