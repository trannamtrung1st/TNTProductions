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
		public int Id { get; set; }
		[JsonProperty("promotionType", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionType { get; set; }
		[JsonProperty("orderId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderId { get; set; }
		[JsonProperty("orderItemId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderItemId { get; set; }
		[JsonProperty("redemptionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionId { get; set; }
		[JsonProperty("redemptionRollbackId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RedemptionRollbackId { get; set; }
		[JsonProperty("voucherCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VoucherCode { get; set; }
		[JsonProperty("promotionCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionCode { get; set; }
		[JsonProperty("discountPercent", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DiscountPercent { get; set; }
		[JsonProperty("discountAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountAmount { get; set; }
		[JsonProperty("giftAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GiftAmount { get; set; }
		[JsonProperty("giftProductCodes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GiftProductCodes { get; set; }
		[JsonProperty("couponCodes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CouponCodes { get; set; }
		[JsonProperty("couponTotalAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> CouponTotalAmount { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("orderItem", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderItemViewModel OrderItemVM { get; set; }
		[JsonProperty("redemption", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionViewModel RedemptionVM { get; set; }
		[JsonProperty("redemptionRollback", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RedemptionRollbackViewModel RedemptionRollbackVM { get; set; }
		
		public PromotionAppliedDetailViewModel(PromotionAppliedDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionAppliedDetailViewModel()
		{
		}
		
	}
}
