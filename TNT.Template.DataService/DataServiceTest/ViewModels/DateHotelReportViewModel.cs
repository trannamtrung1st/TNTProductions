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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("create_by")]
		public string CreateBy { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("store_id")]
		public int StoreID { get; set; }
		[JsonProperty("total_amount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("final_amount")]
		public double FinalAmount { get; set; }
		[JsonProperty("total_order_detail")]
		public double TotalOrderDetail { get; set; }
		[JsonProperty("total_order_fee_item")]
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
