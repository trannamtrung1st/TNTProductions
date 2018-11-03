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
		[JsonProperty("promotion_applied_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionAppliedDetailID { get; set; }
		[JsonProperty("product_iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductIID { get; set; }
		[JsonProperty("product_sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductSID { get; set; }
		[JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Amount { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("promotion_applied_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
