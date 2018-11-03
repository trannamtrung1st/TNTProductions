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
	public partial class PromotionAppliedDetailViewModel: BaseViewModel<PromotionAppliedDetail>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("promotion_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionType { get; set; }
		[JsonProperty("order_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderIID { get; set; }
		[JsonProperty("order_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string OrderSID { get; set; }
		[JsonProperty("order_item_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderItemIID { get; set; }
		[JsonProperty("order_item_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string OrderItemSID { get; set; }
		[JsonProperty("redemption_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionID { get; set; }
		[JsonProperty("redemption_rollback_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionRollbackID { get; set; }
		[JsonProperty("voucher_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VoucherID { get; set; }
		[JsonProperty("promotion_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionID { get; set; }
		[JsonProperty("discount_percent", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountPercent { get; set; }
		[JsonProperty("discount_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountAmount { get; set; }
		[JsonProperty("customer_cashback_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerCashbackDetailID { get; set; }
		[JsonProperty("customer_cashback_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CustomerCashbackAmount { get; set; }
		[JsonProperty("affliator_cashback_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AffliatorCashbackDetailID { get; set; }
		[JsonProperty("affliator_cashback_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> AffliatorCashbackAmount { get; set; }
		[JsonProperty("is_rule_checked", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsRuleChecked { get; set; }
		[JsonProperty("affliator_cashback_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AffliatorCashbackDetailViewModel AffliatorCashbackDetailVM { get; set; }
		[JsonProperty("customer_cashback_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerCashbackDetailViewModel CustomerCashbackDetailVM { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("order_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderItemViewModel OrderItemVM { get; set; }
		[JsonProperty("redemption", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("redemption_rollback", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionRollbackViewModel RedemptionRollbackVM { get; set; }
		[JsonProperty("voucher", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VoucherViewModel VoucherVM { get; set; }
		[JsonProperty("gift_applied_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<GiftAppliedDetailViewModel> GiftAppliedDetailsVM { get; set; }
		
		public PromotionAppliedDetailViewModel(PromotionAppliedDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionAppliedDetailViewModel()
		{
			this.GiftAppliedDetailsVM = new HashSet<GiftAppliedDetailViewModel>();
		}
		
	}
}
