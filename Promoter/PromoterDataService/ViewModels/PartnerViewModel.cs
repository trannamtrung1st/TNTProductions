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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("config", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Config { get; set; }
		[JsonProperty("promotion_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionDetailViewModel> PromotionDetailsVM { get; set; }
		
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
