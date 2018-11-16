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
	public partial class GiftDetailViewModel: BaseViewModel<GiftDetail>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("product_iid")]
		public Nullable<int> ProductIID { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailID { get; set; }
		[JsonProperty("product_sid")]
		public string ProductSID { get; set; }
		[JsonProperty("product_amount")]
		public Nullable<double> ProductAmount { get; set; }
		[JsonProperty("voucher_id")]
		public Nullable<int> VoucherID { get; set; }
		[JsonProperty("voucher_amount")]
		public Nullable<int> VoucherAmount { get; set; }
		[JsonProperty("is_gift_voucher")]
		public Nullable<bool> IsGiftVoucher { get; set; }
		[JsonProperty("and_detail_id")]
		public Nullable<int> AndDetailID { get; set; }
		[JsonProperty("and_detail")]
		public GiftDetailViewModel AndDetailVM { get; set; }
		[JsonProperty("voucher")]
		public VoucherViewModel VoucherVM { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		//[JsonProperty("gift_details1")]
		//public IEnumerable<GiftDetailViewModel> GiftDetails1VM { get; set; }
		
		public GiftDetailViewModel(GiftDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public GiftDetailViewModel()
		{
		}
		
	}
}
