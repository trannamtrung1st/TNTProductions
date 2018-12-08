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
	public partial class PromotionViewModel: BaseViewModel<Promotion>
	{
		[JsonProperty("promotion_id")]
		public int PromotionId { get; set; }
		[JsonProperty("promotion_code")]
		public string PromotionCode { get; set; }
		[JsonProperty("promotion_name")]
		public string PromotionName { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("image_css")]
		public string ImageCss { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_details")]
		public IEnumerable<PromotionDetailViewModel> PromotionDetailsVM { get; set; }
		
		public PromotionViewModel(Promotion entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionViewModel()
		{
			this.PromotionDetailsVM = new HashSet<PromotionDetailViewModel>();
		}
		
	}
}
