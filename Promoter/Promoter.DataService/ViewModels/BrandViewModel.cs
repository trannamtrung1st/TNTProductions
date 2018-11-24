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
	public partial class BrandViewModel: BaseViewModel<Brand>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("brand_accounts")]
		public IEnumerable<BrandAccountViewModel> BrandAccountsVM { get; set; }
		[JsonProperty("memberships")]
		public IEnumerable<MembershipViewModel> MembershipsVM { get; set; }
		
		public BrandViewModel(Brand entity) : this()
		{
			FromEntity(entity);
		}
		
		public BrandViewModel()
		{
			this.BrandAccountsVM = new HashSet<BrandAccountViewModel>();
			this.MembershipsVM = new HashSet<MembershipViewModel>();
		}
		
	}
}