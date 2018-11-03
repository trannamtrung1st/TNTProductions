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
	public partial class TransactionViewModel: BaseViewModel<Transaction>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int AccountId { get; set; }
		[JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal Amount { get; set; }
		[JsonProperty("currency_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CurrencyCode { get; set; }
		[JsonProperty("fcamount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> FCAmount { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("notes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Notes { get; set; }
		[JsonProperty("is_increase_transaction", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsIncreaseTransaction { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserId { get; set; }
		[JsonProperty("transaction_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TransactionType { get; set; }
		[JsonProperty("account", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AccountViewModel AccountVM { get; set; }
		
		public TransactionViewModel(Transaction entity) : this()
		{
			FromEntity(entity);
		}
		
		public TransactionViewModel()
		{
		}
		
	}
}
