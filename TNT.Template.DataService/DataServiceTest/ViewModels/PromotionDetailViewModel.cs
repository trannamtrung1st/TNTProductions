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
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailID { get; set; }
		[JsonProperty("promotion_code")]
		public string PromotionCode { get; set; }
		[JsonProperty("promotion_detail_code")]
		public string PromotionDetailCode { get; set; }
		[JsonProperty("reg_ex_code")]
		public string RegExCode { get; set; }
		[JsonProperty("min_order_amount")]
		public Nullable<double> MinOrderAmount { get; set; }
		[JsonProperty("max_order_amount")]
		public Nullable<double> MaxOrderAmount { get; set; }
		[JsonProperty("buy_product_code")]
		public string BuyProductCode { get; set; }
		[JsonProperty("min_buy_quantity")]
		public Nullable<int> MinBuyQuantity { get; set; }
		[JsonProperty("max_buy_quantity")]
		public Nullable<int> MaxBuyQuantity { get; set; }
		[JsonProperty("gift_product_code")]
		public string GiftProductCode { get; set; }
		[JsonProperty("gift_quantity")]
		public Nullable<int> GiftQuantity { get; set; }
		[JsonProperty("discount_rate")]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("discount_amount")]
		public Nullable<decimal> DiscountAmount { get; set; }
		[JsonProperty("point_trade")]
		public Nullable<int> PointTrade { get; set; }
		[JsonProperty("min_point")]
		public Nullable<int> MinPoint { get; set; }
		[JsonProperty("max_point")]
		public Nullable<int> MaxPoint { get; set; }
		//[JsonProperty("vouchers")]
		//public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
		public PromotionDetailViewModel(PromotionDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionDetailViewModel()
		{
			//this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
