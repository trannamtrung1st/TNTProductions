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
	public partial class CustomerViewModel: BaseViewModel<Customer>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		[JsonProperty("memberships")]
		public IEnumerable<MembershipViewModel> MembershipsVM { get; set; }
		
		public CustomerViewModel(Customer entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerViewModel()
		{
			this.MembershipsVM = new HashSet<MembershipViewModel>();
		}
		
	}
}
