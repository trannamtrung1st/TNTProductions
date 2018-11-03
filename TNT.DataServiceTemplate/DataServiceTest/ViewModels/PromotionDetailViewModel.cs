using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class PromotionDetailViewModel: BaseViewModel<PromotionDetail>
	{
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionDetailID { get; set; }
		[JsonProperty("promotion_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionCode { get; set; }
		[JsonProperty("promotion_detail_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PromotionDetailCode { get; set; }
		[JsonProperty("reg_ex_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RegExCode { get; set; }
		[JsonProperty("min_order_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MinOrderAmount { get; set; }
		[JsonProperty("max_order_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MaxOrderAmount { get; set; }
		[JsonProperty("buy_product_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BuyProductCode { get; set; }
		[JsonProperty("min_buy_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MinBuyQuantity { get; set; }
		[JsonProperty("max_buy_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxBuyQuantity { get; set; }
		[JsonProperty("gift_product_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GiftProductCode { get; set; }
		[JsonProperty("gift_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GiftQuantity { get; set; }
		[JsonProperty("discount_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("discount_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> DiscountAmount { get; set; }
		[JsonProperty("point_trade", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PointTrade { get; set; }
		[JsonProperty("min_point", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MinPoint { get; set; }
		[JsonProperty("max_point", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MaxPoint { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public PromotionDetailViewModel(PromotionDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionDetailViewModel()
		{
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
