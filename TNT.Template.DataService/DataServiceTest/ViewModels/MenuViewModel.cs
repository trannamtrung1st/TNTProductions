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
	public partial class MenuViewModel: BaseViewModel<Menu>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("menu_text")]
		public string MenuText { get; set; }
		[JsonProperty("area")]
		public string Area { get; set; }
		[JsonProperty("controller")]
		public string Controller { get; set; }
		[JsonProperty("action")]
		public string Action { get; set; }
		[JsonProperty("icon_css")]
		public string IconCss { get; set; }
		[JsonProperty("display_order")]
		public int DisplayOrder { get; set; }
		[JsonProperty("parent_menu_id")]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menu_level")]
		public int MenuLevel { get; set; }
		[JsonProperty("status")]
		public bool Status { get; set; }
		[JsonProperty("menu_type_code")]
		public int MenuTypeCode { get; set; }
		[JsonProperty("feature_code")]
		public Nullable<int> FeatureCode { get; set; }
		[JsonProperty("menu_state")]
		public Nullable<int> MenuState { get; set; }
		[JsonProperty("menu_url_code")]
		public Nullable<int> MenuUrlCode { get; set; }
		//[JsonProperty("menu2")]
		//public MenuViewModel Menu2VM { get; set; }
		//[JsonProperty("asp_net_roles")]
		//public AspNetRoleViewModel AspNetRolesVM { get; set; }
		//[JsonProperty("menu1")]
		//public IEnumerable<MenuViewModel> Menu1VM { get; set; }
		
		public MenuViewModel(Menu entity) : this()
		{
			FromEntity(entity);
		}
		
		public MenuViewModel()
		{
			//this.Menu1VM = new HashSet<MenuViewModel>();
		}
		
	}
}
