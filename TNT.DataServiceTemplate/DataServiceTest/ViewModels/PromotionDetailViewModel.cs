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
		[JsonProperty("promotionDetailID")]
		public int PromotionDetailID { get; set; }
		[JsonProperty("promotionCode")]
		public string PromotionCode { get; set; }
		[JsonProperty("promotionDetailCode")]
		public string PromotionDetailCode { get; set; }
		[JsonProperty("regExCode")]
		public string RegExCode { get; set; }
		[JsonProperty("minOrderAmount")]
		public Nullable<double> MinOrderAmount { get; set; }
		[JsonProperty("maxOrderAmount")]
		public Nullable<double> MaxOrderAmount { get; set; }
		[JsonProperty("buyProductCode")]
		public string BuyProductCode { get; set; }
		[JsonProperty("minBuyQuantity")]
		public Nullable<int> MinBuyQuantity { get; set; }
		[JsonProperty("maxBuyQuantity")]
		public Nullable<int> MaxBuyQuantity { get; set; }
		[JsonProperty("giftProductCode")]
		public string GiftProductCode { get; set; }
		[JsonProperty("giftQuantity")]
		public Nullable<int> GiftQuantity { get; set; }
		[JsonProperty("discountRate")]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("discountAmount")]
		public Nullable<decimal> DiscountAmount { get; set; }
		[JsonProperty("pointTrade")]
		public Nullable<int> PointTrade { get; set; }
		[JsonProperty("minPoint")]
		public Nullable<int> MinPoint { get; set; }
		[JsonProperty("maxPoint")]
		public Nullable<int> MaxPoint { get; set; }
		[JsonProperty("vouchers")]
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
