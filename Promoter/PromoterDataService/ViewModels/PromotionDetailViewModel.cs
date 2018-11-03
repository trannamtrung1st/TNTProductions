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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("is_discount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDiscount { get; set; }
		[JsonProperty("discount_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountAmount { get; set; }
		[JsonProperty("discount_unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DiscountUnit { get; set; }
		[JsonProperty("discount_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DiscountLevel { get; set; }
		[JsonProperty("is_gift", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsGift { get; set; }
		[JsonProperty("is_cashback", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsCashback { get; set; }
		[JsonProperty("extra_info_object", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExtraInfoObject { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("is_partner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsPartner { get; set; }
		[JsonProperty("partner_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PartnerIID { get; set; }
		[JsonProperty("partner_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PartnerSID { get; set; }
		[JsonProperty("partner", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PartnerViewModel PartnerVM { get; set; }
		[JsonProperty("affliator_cashback_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AffliatorCashbackDetailViewModel> AffliatorCashbackDetailsVM { get; set; }
		[JsonProperty("customer_cashback_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerCashbackDetailViewModel> CustomerCashbackDetailsVM { get; set; }
		[JsonProperty("gift_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<GiftDetailViewModel> GiftDetailsVM { get; set; }
		[JsonProperty("promotions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionViewModel> PromotionsVM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
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
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
