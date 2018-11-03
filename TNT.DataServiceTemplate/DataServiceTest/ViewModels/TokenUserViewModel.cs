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
	public partial class TokenUserViewModel: BaseViewModel<TokenUser>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Username { get; set; }
		[JsonProperty("token", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Token { get; set; }
		[JsonProperty("create_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateTime { get; set; }
		[JsonProperty("end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> EndTime { get; set; }
		
		public TokenUserViewModel(TokenUser entity) : this()
		{
			FromEntity(entity);
		}
		
		public TokenUserViewModel()
		{
		}
		
	}
}
