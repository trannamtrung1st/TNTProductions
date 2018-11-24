using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Global;
using Promoter.DataService.Models;
using Newtonsoft.Json;

namespace Promoter.DataService.ViewModels
{
	public partial class MembershipAccountViewModel: BaseViewModel<MembershipAccount>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("membership_id")]
		public Nullable<int> MembershipId { get; set; }
		[JsonProperty("balance")]
		public Nullable<double> Balance { get; set; }
		[JsonProperty("membership")]
		public MembershipViewModel MembershipVM { get; set; }
		
		public MembershipAccountViewModel(MembershipAccount entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipAccountViewModel()
		{
		}
		
	}
}