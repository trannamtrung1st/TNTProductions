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
	public partial class RoleViewModel: BaseViewModel<Role>
	{
		[JsonProperty("applicationId")]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("roleId")]
		public System.Guid RoleId { get; set; }
		[JsonProperty("roleName")]
		public string RoleName { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("application")]
		public ApplicationViewModel ApplicationVM { get; set; }
		[JsonProperty("users")]
		public ICollection<UserViewModel> UsersVM { get; set; }
		
		public RoleViewModel(Role entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoleViewModel()
		{
			this.UsersVM = new HashSet<UserViewModel>();
		}
		
	}
}
