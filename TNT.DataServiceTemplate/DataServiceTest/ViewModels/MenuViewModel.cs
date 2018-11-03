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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("menu_text", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MenuText { get; set; }
		[JsonProperty("area", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Area { get; set; }
		[JsonProperty("controller", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Controller { get; set; }
		[JsonProperty("action", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Action { get; set; }
		[JsonProperty("icon_css", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IconCss { get; set; }
		[JsonProperty("display_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DisplayOrder { get; set; }
		[JsonProperty("parent_menu_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menu_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MenuLevel { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Status { get; set; }
		[JsonProperty("menu_type_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MenuTypeCode { get; set; }
		[JsonProperty("feature_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FeatureCode { get; set; }
		[JsonProperty("menu_state", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MenuState { get; set; }
		[JsonProperty("menu_url_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MenuUrlCode { get; set; }
		[JsonProperty("menu2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public MenuViewModel Menu2VM { get; set; }
		[JsonProperty("asp_net_roles", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetRoleViewModel AspNetRolesVM { get; set; }
		[JsonProperty("menu1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<MenuViewModel> Menu1VM { get; set; }
		
		public MenuViewModel(Menu entity) : this()
		{
			FromEntity(entity);
		}
		
		public MenuViewModel()
		{
			this.Menu1VM = new HashSet<MenuViewModel>();
		}
		
	}
}
