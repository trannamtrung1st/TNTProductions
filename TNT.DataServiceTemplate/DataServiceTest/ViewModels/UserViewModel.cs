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
	public partial class UserViewModel: BaseViewModel<User>
	{
		[JsonProperty("application_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.Guid UserId { get; set; }
		[JsonProperty("user_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty("is_anonymous", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAnonymous { get; set; }
		[JsonProperty("last_activity_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime LastActivityDate { get; set; }
		[JsonProperty("application", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ApplicationViewModel ApplicationVM { get; set; }
		[JsonProperty("profile", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProfileViewModel ProfileVM { get; set; }
		[JsonProperty("roles", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RoleViewModel RolesVM { get; set; }
		
		public UserViewModel(User entity) : this()
		{
			FromEntity(entity);
		}
		
		public UserViewModel()
		{
		}
		
	}
}
