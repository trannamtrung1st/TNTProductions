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
	public partial class PromotionApplySituationViewModel: BaseViewModel<PromotionApplySituation>
	{
		[JsonProperty("promotion_detail_id")]
		public int PromotionDetailID { get; set; }
		[JsonProperty("apply_situation")]
		public int ApplySituation { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("promotion_detail")]
		public PromotionDetailViewModel PromotionDetailVM { get; set; }
		
		public PromotionApplySituationViewModel(PromotionApplySituation entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionApplySituationViewModel()
		{
		}
		
	}
}
