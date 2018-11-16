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
	public partial class PromotionTypeViewModel: BaseViewModel<PromotionType>
	{
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailID { get; set; }
		[JsonProperty("promotion_type1")]
		public int PromotionType1 { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public PromotionTypeViewModel(PromotionType entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionTypeViewModel()
		{
		}
		
	}
}
