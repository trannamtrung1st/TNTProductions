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
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("aspNetUsers")]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("menus")]
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
