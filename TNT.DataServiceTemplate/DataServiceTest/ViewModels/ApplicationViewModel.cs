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
		[JsonProperty("applicationName")]
		public string ApplicationName { get; set; }
		[JsonProperty("applicationId")]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("roles")]
		public ICollection<RoleViewModel> RolesVM { get; set; }
		[JsonProperty("users")]
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
