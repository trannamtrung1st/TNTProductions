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
	public partial class AspNetUserClaimViewModel: BaseViewModel<AspNetUserClaim>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserId { get; set; }
		[JsonProperty("claim_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ClaimType { get; set; }
		[JsonProperty("claim_value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ClaimValue { get; set; }
		[JsonProperty("asp_net_user", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetUserViewModel AspNetUserVM { get; set; }
		
		public AspNetUserClaimViewModel(AspNetUserClaim entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetUserClaimViewModel()
		{
		}
		
	}
}
