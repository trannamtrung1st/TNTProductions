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
		[JsonProperty("applicationId")]
		public System.Guid ApplicationId { get; set; }
		[JsonProperty("userId")]
		public System.Guid UserId { get; set; }
		[JsonProperty("userName")]
		public string UserName { get; set; }
		[JsonProperty("isAnonymous")]
		public bool IsAnonymous { get; set; }
		[JsonProperty("lastActivityDate")]
		public DateTime LastActivityDate { get; set; }
		[JsonProperty("application")]
		public ApplicationViewModel ApplicationVM { get; set; }
		[JsonProperty("profile")]
		public ProfileViewModel ProfileVM { get; set; }
		[JsonProperty("roles")]
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
