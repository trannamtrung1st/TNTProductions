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
	public partial class AspNetUserLoginViewModel: BaseViewModel<AspNetUserLogin>
	{
		[JsonProperty("login_provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LoginProvider { get; set; }
		[JsonProperty("provider_key", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProviderKey { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserId { get; set; }
		[JsonProperty("asp_net_user", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetUserViewModel AspNetUserVM { get; set; }
		
		public AspNetUserLoginViewModel(AspNetUserLogin entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetUserLoginViewModel()
		{
		}
		
	}
}
