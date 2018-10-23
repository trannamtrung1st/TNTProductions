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
		[JsonProperty("loginProvider")]
		public string LoginProvider { get; set; }
		[JsonProperty("providerKey")]
		public string ProviderKey { get; set; }
		[JsonProperty("userId")]
		public string UserId { get; set; }
		[JsonProperty("aspNetUser")]
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
