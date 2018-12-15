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
	public partial class WebMenuCategoryViewModel: BaseViewModel<WebMenuCategory>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("is_menu_system")]
		public bool IsMenuSystem { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("web_menus")]
		//public IEnumerable<WebMenuViewModel> WebMenusVM { get; set; }
		
		public WebMenuCategoryViewModel(WebMenuCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebMenuCategoryViewModel()
		{
			//this.WebMenusVM = new HashSet<WebMenuViewModel>();
		}
		
	}
}
