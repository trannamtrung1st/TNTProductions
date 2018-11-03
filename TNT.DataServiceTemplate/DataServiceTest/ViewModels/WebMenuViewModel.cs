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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("menu_text", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MenuText { get; set; }
		[JsonProperty("menu_text1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MenuText1 { get; set; }
		[JsonProperty("menu_text2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MenuText2 { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Type { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("icon_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IconUrl { get; set; }
		[JsonProperty("display_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DisplayOrder { get; set; }
		[JsonProperty("parent_menu_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menu_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MenuLevel { get; set; }
		[JsonProperty("store_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("is_system_menu", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsSystemMenu { get; set; }
		[JsonProperty("category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CategoryId { get; set; }
		[JsonProperty("web_menu2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public WebMenuViewModel WebMenu2VM { get; set; }
		[JsonProperty("web_menu_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public WebMenuCategoryViewModel WebMenuCategoryVM { get; set; }
		[JsonProperty("web_menu1", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
