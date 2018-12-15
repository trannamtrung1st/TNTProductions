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
		[JsonProperty("payment_id")]
		public int PaymentID { get; set; }
		[JsonProperty("to_rent_id")]
		public Nullable<int> ToRentID { get; set; }
		[JsonProperty("amount")]
		public double Amount { get; set; }
		[JsonProperty("currency_code")]
		public string CurrencyCode { get; set; }
		[JsonProperty("fcamount")]
		public decimal FCAmount { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("pay_time")]
		public DateTime PayTime { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("real_amount")]
		public Nullable<double> RealAmount { get; set; }
		[JsonProperty("card_code")]
		public string CardCode { get; set; }
		[JsonProperty("cost_id")]
		public Nullable<int> CostID { get; set; }
		//[JsonProperty("cost")]
		//public CostViewModel CostVM { get; set; }
		//[JsonProperty("order")]
		//public OrderViewModel OrderVM { get; set; }
		
		public PaymentViewModel(Payment entity) : this()
		{
			FromEntity(entity);
		}
		
		public PaymentViewModel()
		{
		}
		
	}
}
