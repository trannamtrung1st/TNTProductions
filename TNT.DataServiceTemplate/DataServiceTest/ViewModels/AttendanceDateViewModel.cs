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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("date_report", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime DateReport { get; set; }
		[JsonProperty("total_employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalEmployee { get; set; }
		[JsonProperty("total_on_time_employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOnTimeEmployee { get; set; }
		[JsonProperty("total_session", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalSession { get; set; }
		[JsonProperty("total_on_time_session", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalOnTimeSession { get; set; }
		[JsonProperty("total_miss_session", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalMissSession { get; set; }
		[JsonProperty("total_miss_employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalMissEmployee { get; set; }
		[JsonProperty("total_come_late", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalComeLate { get; set; }
		[JsonProperty("total_come_on_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalComeOnTime { get; set; }
		[JsonProperty("total_return_early", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalReturnEarly { get; set; }
		[JsonProperty("total_return_ontime", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalReturnOntime { get; set; }
		[JsonProperty("total_working_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan TotalWorkingTime { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public AttendanceDateViewModel(AttendanceDate entity) : this()
		{
			FromEntity(entity);
		}
		
		public AttendanceDateViewModel()
		{
		}
		
	}
}
