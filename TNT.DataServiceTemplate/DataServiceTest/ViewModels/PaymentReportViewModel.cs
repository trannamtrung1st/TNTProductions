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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("createBy")]
		public string CreateBy { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("cashAmount")]
		public double CashAmount { get; set; }
		[JsonProperty("memberCardAmount")]
		public double MemberCardAmount { get; set; }
		[JsonProperty("bankAmount")]
		public double BankAmount { get; set; }
		[JsonProperty("voucherAmount")]
		public double VoucherAmount { get; set; }
		[JsonProperty("debtAmount")]
		public double DebtAmount { get; set; }
		[JsonProperty("otherAmount")]
		public double OtherAmount { get; set; }
		[JsonProperty("payDebtAmount")]
		public double PayDebtAmount { get; set; }
		[JsonProperty("receiptAmount")]
		public double ReceiptAmount { get; set; }
		[JsonProperty("spendAmount")]
		public double SpendAmount { get; set; }
		[JsonProperty("store")]
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
