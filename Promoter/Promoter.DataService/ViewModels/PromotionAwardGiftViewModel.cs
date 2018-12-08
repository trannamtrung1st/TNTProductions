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
	public partial class PromotionAwardGiftViewModel: BaseViewModel<PromotionAwardGift>
	{
		[JsonProperty("promotion_award_id")]
		public int PromotionAwardId { get; set; }
		[JsonProperty("for_product_id")]
		public Nullable<int> ForProductId { get; set; }
		[JsonProperty("gift_voucher_id")]
		public Nullable<int> GiftVoucherId { get; set; }
		[JsonProperty("gift_voucher_of_promotion_id")]
		public Nullable<int> GiftVoucherOfPromotionId { get; set; }
		[JsonProperty("gift_present_id")]
		public Nullable<int> GiftPresentId { get; set; }
		[JsonProperty("gift_product_id")]
		public Nullable<int> GiftProductId { get; set; }
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public PromotionAwardGiftViewModel(PromotionAwardGift entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionAwardGiftViewModel()
		{
		}
		
	}
}
