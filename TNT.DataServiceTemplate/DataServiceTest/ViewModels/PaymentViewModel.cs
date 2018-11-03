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
		[JsonProperty("payment_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PaymentID { get; set; }
		[JsonProperty("to_rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ToRentID { get; set; }
		[JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Amount { get; set; }
		[JsonProperty("currency_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CurrencyCode { get; set; }
		[JsonProperty("fcamount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal FCAmount { get; set; }
		[JsonProperty("notes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Notes { get; set; }
		[JsonProperty("pay_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime PayTime { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("real_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> RealAmount { get; set; }
		[JsonProperty("card_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CardCode { get; set; }
		[JsonProperty("cost_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CostID { get; set; }
		[JsonProperty("cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CostViewModel CostVM { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
