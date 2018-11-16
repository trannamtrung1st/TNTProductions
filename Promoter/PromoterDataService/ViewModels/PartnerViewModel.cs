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
	public partial class PartnerViewModel: BaseViewModel<Partner>
	{
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("config")]
		public string Config { get; set; }
		[JsonProperty("promotion_details")]
		public IEnumerable<PromotionDetailViewModel> PromotionDetailsVM { get; set; }
		
		public PartnerViewModel(Partner entity) : this()
		{
			FromEntity(entity);
		}
		
		public PartnerViewModel()
		{
			this.PromotionDetailsVM = new HashSet<PromotionDetailViewModel>();
		}
		
	}
}
