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
		[JsonProperty("menu_text")]
		public string MenuText { get; set; }
		[JsonProperty("menu_text1")]
		public string MenuText1 { get; set; }
		[JsonProperty("menu_text2")]
		public string MenuText2 { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("icon_url")]
		public string IconUrl { get; set; }
		[JsonProperty("display_order")]
		public int DisplayOrder { get; set; }
		[JsonProperty("parent_menu_id")]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menu_level")]
		public Nullable<int> MenuLevel { get; set; }
		[JsonProperty("store_filter")]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("is_system_menu")]
		public bool IsSystemMenu { get; set; }
		[JsonProperty("category_id")]
		public int CategoryId { get; set; }
		//[JsonProperty("web_menu2")]
		//public WebMenuViewModel WebMenu2VM { get; set; }
		//[JsonProperty("web_menu_category")]
		//public WebMenuCategoryViewModel WebMenuCategoryVM { get; set; }
		//[JsonProperty("web_menu1")]
		//public IEnumerable<WebMenuViewModel> WebMenu1VM { get; set; }
		
		public WebMenuViewModel(WebMenu entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebMenuViewModel()
		{
			//this.WebMenu1VM = new HashSet<WebMenuViewModel>();
		}
		
	}
}
