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
	public partial class GiftAppliedDetailViewModel: BaseViewModel<GiftAppliedDetail>
	{
		[JsonProperty("promotion_applied_detail_id")]
		public int PromotionAppliedDetailID { get; set; }
		[JsonProperty("product_iid")]
		public int ProductIID { get; set; }
		[JsonProperty("product_sid")]
		public string ProductSID { get; set; }
		[JsonProperty("amount")]
		public Nullable<double> Amount { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("promotion_applied_detail")]
		public PromotionAppliedDetailViewModel PromotionAppliedDetailVM { get; set; }
		
		public GiftAppliedDetailViewModel(GiftAppliedDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public GiftAppliedDetailViewModel()
		{
		}
		
	}
}
