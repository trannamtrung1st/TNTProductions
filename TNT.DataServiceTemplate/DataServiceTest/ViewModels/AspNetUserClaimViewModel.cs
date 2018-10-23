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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("userId")]
		public string UserId { get; set; }
		[JsonProperty("claimType")]
		public string ClaimType { get; set; }
		[JsonProperty("claimValue")]
		public string ClaimValue { get; set; }
		[JsonProperty("aspNetUser")]
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
