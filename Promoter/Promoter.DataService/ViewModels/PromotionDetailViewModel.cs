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
	public partial class PromotionDetailViewModel: BaseViewModel<PromotionDetail>
	{
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailId { get; set; }
		[JsonProperty("detail_code")]
		public string DetailCode { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("apply_quantity")]
		public Nullable<int> ApplyQuantity { get; set; }
		[JsonProperty("applied_quantity")]
		public Nullable<int> AppliedQuantity { get; set; }
		[JsonProperty("has_voucher")]
		public bool HasVoucher { get; set; }
		[JsonProperty("voucher_quantity")]
		public Nullable<int> VoucherQuantity { get; set; }
		[JsonProperty("voucher_used_quantity")]
		public Nullable<int> VoucherUsedQuantity { get; set; }
		[JsonProperty("award_discount")]
		public bool AwardDiscount { get; set; }
		[JsonProperty("award_gift")]
		public bool AwardGift { get; set; }
		[JsonProperty("award_cashback")]
		public bool AwardCashback { get; set; }
		[JsonProperty("auto_gen_length")]
		public Nullable<int> AutoGenLength { get; set; }
		[JsonProperty("prefix")]
		public string Prefix { get; set; }
		[JsonProperty("postfix")]
		public string Postfix { get; set; }
		[JsonProperty("pattern")]
		public string Pattern { get; set; }
		[JsonProperty("promotion_partner_id")]
		public Nullable<int> PromotionPartnerId { get; set; }
		[JsonProperty("promotion_id")]
		public int PromotionId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion")]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("promotion_award_cashbacks")]
		public IEnumerable<PromotionAwardCashbackViewModel> PromotionAwardCashbacksVM { get; set; }
		[JsonProperty("promotion_award_discounts")]
		public IEnumerable<PromotionAwardDiscountViewModel> PromotionAwardDiscountsVM { get; set; }
		[JsonProperty("promotion_award_gifts")]
		public IEnumerable<PromotionAwardGiftViewModel> PromotionAwardGiftsVM { get; set; }
		[JsonProperty("promotion_constraints")]
		public IEnumerable<PromotionConstraintViewModel> PromotionConstraintsVM { get; set; }
		[JsonProperty("vouchers")]
		public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
		public PromotionDetailViewModel(PromotionDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionDetailViewModel()
		{
			this.PromotionAwardCashbacksVM = new HashSet<PromotionAwardCashbackViewModel>();
			this.PromotionAwardDiscountsVM = new HashSet<PromotionAwardDiscountViewModel>();
			this.PromotionAwardGiftsVM = new HashSet<PromotionAwardGiftViewModel>();
			this.PromotionConstraintsVM = new HashSet<PromotionConstraintViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
