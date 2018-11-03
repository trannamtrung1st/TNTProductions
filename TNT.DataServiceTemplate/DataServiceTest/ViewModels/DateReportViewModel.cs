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
	public partial class DateReportViewModel: BaseViewModel<DateReport>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("create_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreateBy { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("discount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Discount { get; set; }
		[JsonProperty("discount_order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountOrderDetail { get; set; }
		[JsonProperty("total_cash", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalCash { get; set; }
		[JsonProperty("total_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOrder { get; set; }
		[JsonProperty("total_order_at_store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOrderAtStore { get; set; }
		[JsonProperty("total_order_take_away", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOrderTakeAway { get; set; }
		[JsonProperty("total_order_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOrderDelivery { get; set; }
		[JsonProperty("total_order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalOrderDetail { get; set; }
		[JsonProperty("total_order_fee_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalOrderFeeItem { get; set; }
		[JsonProperty("total_order_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOrderCard { get; set; }
		[JsonProperty("total_order_canceled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalOrderCanceled { get; set; }
		[JsonProperty("total_order_pre_canceled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalOrderPreCanceled { get; set; }
		[JsonProperty("final_amount_at_store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountAtStore { get; set; }
		[JsonProperty("final_amount_take_away", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountTakeAway { get; set; }
		[JsonProperty("final_amount_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountDelivery { get; set; }
		[JsonProperty("final_amount_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountCard { get; set; }
		[JsonProperty("final_amount_canceled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountCanceled { get; set; }
		[JsonProperty("final_amount_pre_canceled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmountPreCanceled { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public DateReportViewModel(DateReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateReportViewModel()
		{
		}
		
	}
}
