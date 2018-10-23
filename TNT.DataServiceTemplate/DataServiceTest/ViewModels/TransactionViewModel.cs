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
		[JsonProperty("accountId")]
		public int AccountId { get; set; }
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
		[JsonProperty("currencyCode")]
		public string CurrencyCode { get; set; }
		[JsonProperty("fCAmount")]
		public Nullable<decimal> FCAmount { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("isIncreaseTransaction")]
		public bool IsIncreaseTransaction { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("userId")]
		public string UserId { get; set; }
		[JsonProperty("transactionType")]
		public int TransactionType { get; set; }
		[JsonProperty("account")]
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
