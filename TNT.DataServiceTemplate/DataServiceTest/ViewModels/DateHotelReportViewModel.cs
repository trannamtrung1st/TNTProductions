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
		[JsonProperty("createBy")]
		public string CreateBy { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("finalAmount")]
		public double FinalAmount { get; set; }
		[JsonProperty("totalOrderDetail")]
		public double TotalOrderDetail { get; set; }
		[JsonProperty("totalOrderFeeItem")]
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
