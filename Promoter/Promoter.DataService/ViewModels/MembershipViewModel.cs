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
	public partial class MembershipViewModel: BaseViewModel<Membership>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("customer_id")]
		public int CustomerId { get; set; }
		[JsonProperty("since")]
		public Nullable<DateTime> Since { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("membership_accounts")]
		public IEnumerable<MembershipAccountViewModel> MembershipAccountsVM { get; set; }
		[JsonProperty("membership_cards")]
		public IEnumerable<MembershipCardViewModel> MembershipCardsVM { get; set; }
		
		public MembershipViewModel(Membership entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipViewModel()
		{
			this.MembershipAccountsVM = new HashSet<MembershipAccountViewModel>();
			this.MembershipCardsVM = new HashSet<MembershipCardViewModel>();
		}
		
	}
}
