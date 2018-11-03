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
	public partial class DateHotelReportViewModel: BaseViewModel<DateHotelReport>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("create_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreateBy { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalAmount { get; set; }
		[JsonProperty("discount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Discount { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double FinalAmount { get; set; }
		[JsonProperty("total_order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalOrderDetail { get; set; }
		[JsonProperty("total_order_fee_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalOrderFeeItem { get; set; }
		
		public DateHotelReportViewModel(DateHotelReport entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateHotelReportViewModel()
		{
		}
		
	}
}
