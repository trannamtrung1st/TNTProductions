using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class WebMenuViewModel: BaseViewModel<WebMenu>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("menuText")]
		public string MenuText { get; set; }
		[JsonProperty("menuText1")]
		public string MenuText1 { get; set; }
		[JsonProperty("menuText2")]
		public string MenuText2 { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("iconUrl")]
		public string IconUrl { get; set; }
		[JsonProperty("displayOrder")]
		public int DisplayOrder { get; set; }
		[JsonProperty("parentMenuId")]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menuLevel")]
		public Nullable<int> MenuLevel { get; set; }
		[JsonProperty("storeFilter")]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("isSystemMenu")]
		public bool IsSystemMenu { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("webMenu2")]
		public WebMenuViewModel WebMenu2VM { get; set; }
		[JsonProperty("webMenuCategory")]
		public WebMenuCategoryViewModel WebMenuCategoryVM { get; set; }
		[JsonProperty("webMenu1")]
		public ICollection<WebMenuViewModel> WebMenu1VM { get; set; }
		
		public WebMenuViewModel(WebMenu entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebMenuViewModel()
		{
			this.WebMenu1VM = new HashSet<WebMenuViewModel>();
		}
		
	}
}
