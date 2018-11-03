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
	public partial class AspNetRoleViewModel: BaseViewModel<AspNetRole>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("asp_net_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("menus", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<MenuViewModel> MenusVM { get; set; }
		
		public AspNetRoleViewModel(AspNetRole entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetRoleViewModel()
		{
			this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			this.MenusVM = new HashSet<MenuViewModel>();
		}
		
	}
}
