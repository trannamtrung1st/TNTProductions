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
		[JsonProperty("menuText")]
		public string MenuText { get; set; }
		[JsonProperty("area")]
		public string Area { get; set; }
		[JsonProperty("controller")]
		public string Controller { get; set; }
		[JsonProperty("action")]
		public string Action { get; set; }
		[JsonProperty("iconCss")]
		public string IconCss { get; set; }
		[JsonProperty("displayOrder")]
		public int DisplayOrder { get; set; }
		[JsonProperty("parentMenuId")]
		public Nullable<int> ParentMenuId { get; set; }
		[JsonProperty("menuLevel")]
		public int MenuLevel { get; set; }
		[JsonProperty("status")]
		public bool Status { get; set; }
		[JsonProperty("menuTypeCode")]
		public int MenuTypeCode { get; set; }
		[JsonProperty("featureCode")]
		public Nullable<int> FeatureCode { get; set; }
		[JsonProperty("menuState")]
		public Nullable<int> MenuState { get; set; }
		[JsonProperty("menuUrlCode")]
		public Nullable<int> MenuUrlCode { get; set; }
		[JsonProperty("menu2")]
		public MenuViewModel Menu2VM { get; set; }
		[JsonProperty("aspNetRoles")]
		public AspNetRoleViewModel AspNetRolesVM { get; set; }
		[JsonProperty("menu1")]
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
