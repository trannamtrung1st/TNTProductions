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
	public partial class PaymentViewModel: BaseViewModel<Payment>
	{
		[JsonProperty("paymentID")]
		public int PaymentID { get; set; }
		[JsonProperty("toRentID")]
		public Nullable<int> ToRentID { get; set; }
		[JsonProperty("amount")]
		public double Amount { get; set; }
		[JsonProperty("currencyCode")]
		public string CurrencyCode { get; set; }
		[JsonProperty("fCAmount")]
		public decimal FCAmount { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("payTime")]
		public DateTime PayTime { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("realAmount")]
		public Nullable<double> RealAmount { get; set; }
		[JsonProperty("cardCode")]
		public string CardCode { get; set; }
		[JsonProperty("costID")]
		public Nullable<int> CostID { get; set; }
		[JsonProperty("cost")]
		public CostViewModel CostVM { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		
		public PaymentViewModel(Payment entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaymentViewModel()
		{
		}
		
	}
}
