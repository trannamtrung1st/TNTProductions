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
	public partial class AttendanceDateViewModel: BaseViewModel<AttendanceDate>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("date_report")]
		public DateTime DateReport { get; set; }
		[JsonProperty("total_employee")]
		public int TotalEmployee { get; set; }
		[JsonProperty("total_on_time_employee")]
		public int TotalOnTimeEmployee { get; set; }
		[JsonProperty("total_session")]
		public int TotalSession { get; set; }
		[JsonProperty("total_on_time_session")]
		public int TotalOnTimeSession { get; set; }
		[JsonProperty("total_miss_session")]
		public int TotalMissSession { get; set; }
		[JsonProperty("total_miss_employee")]
		public int TotalMissEmployee { get; set; }
		[JsonProperty("total_come_late")]
		public int TotalComeLate { get; set; }
		[JsonProperty("total_come_on_time")]
		public int TotalComeOnTime { get; set; }
		[JsonProperty("total_return_early")]
		public int TotalReturnEarly { get; set; }
		[JsonProperty("total_return_ontime")]
		public int TotalReturnOntime { get; set; }
		[JsonProperty("total_working_time")]
		public System.TimeSpan TotalWorkingTime { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public AttendanceDateViewModel(AttendanceDate entity) : this()
		{
			FromEntity(entity);
		}
		
		public AttendanceDateViewModel()
		{
		}
		
	}
}
