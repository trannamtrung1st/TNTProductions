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
		[JsonProperty("login_provider")]
		public string LoginProvider { get; set; }
		[JsonProperty("provider_key")]
		public string ProviderKey { get; set; }
		[JsonProperty("user_id")]
		public string UserId { get; set; }
		//[JsonProperty("asp_net_user")]
		//public AspNetUserViewModel AspNetUserVM { get; set; }
		
		public AspNetUserLoginViewModel(AspNetUserLogin entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetUserLoginViewModel()
		{
		}
		
	}
}
