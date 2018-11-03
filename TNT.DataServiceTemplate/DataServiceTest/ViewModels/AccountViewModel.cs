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
	public partial class AccountViewModel: BaseViewModel<Account>
	{
		[JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int AccountID { get; set; }
		[JsonProperty("account_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AccountCode { get; set; }
		[JsonProperty("account_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AccountName { get; set; }
		[JsonProperty("level__", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public short Level_ { get; set; }
		[JsonProperty("start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("finish_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> FinishDate { get; set; }
		[JsonProperty("balance", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> Balance { get; set; }
		[JsonProperty("product_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductCode { get; set; }
		[JsonProperty("membership_card_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MembershipCardId { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("membership_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public MembershipCardViewModel MembershipCardVM { get; set; }
		[JsonProperty("transactions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TransactionViewModel> TransactionsVM { get; set; }
		
		public AccountViewModel(Account entity) : this()
		{
			FromEntity(entity);
		}
		
		public AccountViewModel()
		{
			this.TransactionsVM = new HashSet<TransactionViewModel>();
		}
		
	}
}
