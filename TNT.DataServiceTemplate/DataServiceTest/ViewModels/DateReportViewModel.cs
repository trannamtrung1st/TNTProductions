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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("createBy")]
		public string CreateBy { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("totalAmount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("finalAmount")]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("discount")]
		public Nullable<double> Discount { get; set; }
		[JsonProperty("discountOrderDetail")]
		public Nullable<double> DiscountOrderDetail { get; set; }
		[JsonProperty("totalCash")]
		public Nullable<double> TotalCash { get; set; }
		[JsonProperty("totalOrder")]
		public int TotalOrder { get; set; }
		[JsonProperty("totalOrderAtStore")]
		public int TotalOrderAtStore { get; set; }
		[JsonProperty("totalOrderTakeAway")]
		public int TotalOrderTakeAway { get; set; }
		[JsonProperty("totalOrderDelivery")]
		public int TotalOrderDelivery { get; set; }
		[JsonProperty("totalOrderDetail")]
		public double TotalOrderDetail { get; set; }
		[JsonProperty("totalOrderFeeItem")]
		public double TotalOrderFeeItem { get; set; }
		[JsonProperty("totalOrderCard")]
		public int TotalOrderCard { get; set; }
		[JsonProperty("totalOrderCanceled")]
		public Nullable<int> TotalOrderCanceled { get; set; }
		[JsonProperty("totalOrderPreCanceled")]
		public Nullable<int> TotalOrderPreCanceled { get; set; }
		[JsonProperty("finalAmountAtStore")]
		public Nullable<double> FinalAmountAtStore { get; set; }
		[JsonProperty("finalAmountTakeAway")]
		public Nullable<double> FinalAmountTakeAway { get; set; }
		[JsonProperty("finalAmountDelivery")]
		public Nullable<double> FinalAmountDelivery { get; set; }
		[JsonProperty("finalAmountCard")]
		public Nullable<double> FinalAmountCard { get; set; }
		[JsonProperty("finalAmountCanceled")]
		public Nullable<double> FinalAmountCanceled { get; set; }
		[JsonProperty("finalAmountPreCanceled")]
		public Nullable<double> FinalAmountPreCanceled { get; set; }
		[JsonProperty("store")]
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
