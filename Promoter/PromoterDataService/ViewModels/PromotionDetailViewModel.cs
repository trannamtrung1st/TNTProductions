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
		public int Id { get; set; }
		[JsonProperty("isDiscount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDiscount { get; set; }
		[JsonProperty("discountAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DiscountAmount { get; set; }
		[JsonProperty("discountUnit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DiscountUnit { get; set; }
		[JsonProperty("discountUnitValue", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DiscountUnitValue { get; set; }
		[JsonProperty("isGift", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsGift { get; set; }
		[JsonProperty("giftAmounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GiftAmounts { get; set; }
		[JsonProperty("giftCodesExpr", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GiftCodesExpr { get; set; }
		[JsonProperty("giftUnits", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GiftUnits { get; set; }
		[JsonProperty("deactive", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Deactive { get; set; }
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
			this.PromotionsVM = new HashSet<PromotionViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
