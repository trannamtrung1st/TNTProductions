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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("is_menu_system", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsMenuSystem { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("web_menus", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<WebMenuViewModel> WebMenusVM { get; set; }
		
		public WebMenuCategoryViewModel(WebMenuCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public WebMenuCategoryViewModel()
		{
			this.WebMenusVM = new HashSet<WebMenuViewModel>();
		}
		
	}
}
