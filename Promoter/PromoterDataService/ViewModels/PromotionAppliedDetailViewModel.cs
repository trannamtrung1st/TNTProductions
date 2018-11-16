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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("promotion_type")]
		public Nullable<int> PromotionType { get; set; }
		[JsonProperty("order_iid")]
		public Nullable<int> OrderIID { get; set; }
		[JsonProperty("order_sid")]
		public string OrderSID { get; set; }
		[JsonProperty("order_item_iid")]
		public Nullable<int> OrderItemIID { get; set; }
		[JsonProperty("order_item_sid")]
		public string OrderItemSID { get; set; }
		[JsonProperty("redemption_id")]
		public Nullable<int> RedemptionID { get; set; }
		[JsonProperty("redemption_rollback_id")]
		public Nullable<int> RedemptionRollbackID { get; set; }
		[JsonProperty("voucher_id")]
		public Nullable<int> VoucherID { get; set; }
		[JsonProperty("promotion_id")]
		public Nullable<int> PromotionID { get; set; }
		[JsonProperty("discount_percent")]
		public Nullable<double> DiscountPercent { get; set; }
		[JsonProperty("discount_amount")]
		public Nullable<double> DiscountAmount { get; set; }
		[JsonProperty("customer_cashback_detail_id")]
		public Nullable<int> CustomerCashbackDetailID { get; set; }
		[JsonProperty("customer_cashback_amount")]
		public Nullable<double> CustomerCashbackAmount { get; set; }
		[JsonProperty("affliator_cashback_detail_id")]
		public Nullable<int> AffliatorCashbackDetailID { get; set; }
		[JsonProperty("affliator_cashback_amount")]
		public Nullable<double> AffliatorCashbackAmount { get; set; }
		[JsonProperty("strict_rule")]
		public Nullable<bool> StrictRule { get; set; }
		[JsonProperty("affliator_cashback_detail")]
		public AffliatorCashbackDetailViewModel AffliatorCashbackDetailVM { get; set; }
		[JsonProperty("customer_cashback_detail")]
		public CustomerCashbackDetailViewModel CustomerCashbackDetailVM { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("order_item")]
		public OrderItemViewModel OrderItemVM { get; set; }
		[JsonProperty("promotion")]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("redemption")]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("redemption_rollback")]
		public RedemptionRollbackViewModel RedemptionRollbackVM { get; set; }
		[JsonProperty("voucher")]
		public VoucherViewModel VoucherVM { get; set; }
		[JsonProperty("gift_applied_details")]
		public IEnumerable<GiftAppliedDetailViewModel> GiftAppliedDetailsVM { get; set; }
		
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
