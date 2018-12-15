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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("account_id")]
		public int AccountId { get; set; }
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
		[JsonProperty("currency_code")]
		public string CurrencyCode { get; set; }
		[JsonProperty("fcamount")]
		public Nullable<decimal> FCAmount { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("is_increase_transaction")]
		public bool IsIncreaseTransaction { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("user_id")]
		public string UserId { get; set; }
		[JsonProperty("transaction_type")]
		public int TransactionType { get; set; }
		//[JsonProperty("account")]
		//public AccountViewModel AccountVM { get; set; }
		
		public TransactionViewModel(Transaction entity) : this()
		{
			FromEntity(entity);
		}
		
		public TransactionViewModel()
		{
		}
		
	}
}
