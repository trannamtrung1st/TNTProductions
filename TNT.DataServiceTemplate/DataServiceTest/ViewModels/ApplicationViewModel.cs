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
	public partial class ApplicationViewModel: BaseViewModel<Application>
	{
		[JsonProperty("application_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApplicationName { get; set; }
		[JsonProperty("application_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("roles", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoleViewModel> RolesVM { get; set; }
		[JsonProperty("users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<UserViewModel> UsersVM { get; set; }
		
		public ApplicationViewModel(Application entity) : this()
		{
			FromEntity(entity);
		}
		
		public ApplicationViewModel()
		{
			this.RolesVM = new HashSet<RoleViewModel>();
			this.UsersVM = new HashSet<UserViewModel>();
		}
		
	}
}
