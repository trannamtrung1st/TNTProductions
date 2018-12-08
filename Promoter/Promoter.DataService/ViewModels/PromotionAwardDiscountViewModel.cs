using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Global;
using Promoter.DataService.Models;
using Newtonsoft.Json;

namespace Promoter.DataService.ViewModels
{
	public partial class PromotionAwardDiscountViewModel: BaseViewModel<PromotionAwardDiscount>
	{
		[JsonProperty("promotion_award_id")]
		public int PromotionAwardId { get; set; }
		[JsonProperty("for_product_id")]
		public Nullable<int> ForProductId { get; set; }
		[JsonProperty("buy_xget_yamount")]
		public Nullable<int> BuyXGetYAmount { get; set; }
		[JsonProperty("fixed_upsize_price")]
		public Nullable<double> FixedUpsizePrice { get; set; }
		[JsonProperty("sync_price")]
		public Nullable<double> SyncPrice { get; set; }
		[JsonProperty("discount_amout")]
		public Nullable<double> DiscountAmout { get; set; }
		[JsonProperty("discount_percent")]
		public Nullable<double> DiscountPercent { get; set; }
		[JsonProperty("ship_discount")]
		public Nullable<double> ShipDiscount { get; set; }
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public PromotionAwardDiscountViewModel(PromotionAwardDiscount entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionAwardDiscountViewModel()
		{
		}
		
	}
}
