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
		[JsonProperty("accountID")]
		public int AccountID { get; set; }
		[JsonProperty("accountCode")]
		public string AccountCode { get; set; }
		[JsonProperty("accountName")]
		public string AccountName { get; set; }
		[JsonProperty("level_")]
		public short Level_ { get; set; }
		[JsonProperty("startDate")]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("finishDate")]
		public Nullable<DateTime> FinishDate { get; set; }
		[JsonProperty("balance")]
		public Nullable<decimal> Balance { get; set; }
		[JsonProperty("productCode")]
		public string ProductCode { get; set; }
		[JsonProperty("membershipCardId")]
		public Nullable<int> MembershipCardId { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("membershipCard")]
		public MembershipCardViewModel MembershipCardVM { get; set; }
		[JsonProperty("transactions")]
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
