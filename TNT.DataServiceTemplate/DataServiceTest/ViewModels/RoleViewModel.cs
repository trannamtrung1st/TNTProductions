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
		[JsonProperty("application_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("role_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid RoleId { get; set; }
		[JsonProperty("role_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RoleName { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("application", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ApplicationViewModel ApplicationVM { get; set; }
		[JsonProperty("users", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
