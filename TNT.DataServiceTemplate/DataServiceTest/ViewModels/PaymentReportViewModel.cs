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
	public partial class PaymentReportViewModel: BaseViewModel<PaymentReport>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("create_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreateBy { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("cash_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double CashAmount { get; set; }
		[JsonProperty("member_card_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double MemberCardAmount { get; set; }
		[JsonProperty("bank_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double BankAmount { get; set; }
		[JsonProperty("voucher_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double VoucherAmount { get; set; }
		[JsonProperty("debt_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DebtAmount { get; set; }
		[JsonProperty("other_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double OtherAmount { get; set; }
		[JsonProperty("pay_debt_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double PayDebtAmount { get; set; }
		[JsonProperty("receipt_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double ReceiptAmount { get; set; }
		[JsonProperty("spend_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double SpendAmount { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public PaymentReportViewModel(PaymentReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaymentReportViewModel()
		{
		}
		
	}
}
