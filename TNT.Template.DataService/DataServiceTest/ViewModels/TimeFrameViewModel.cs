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
	public partial class TimeFrameViewModel: BaseViewModel<TimeFrame>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("start_time")]
		public System.TimeSpan StartTime { get; set; }
		[JsonProperty("end_time")]
		public System.TimeSpan EndTime { get; set; }
		[JsonProperty("duration")]
		public System.TimeSpan Duration { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("employee_group_id")]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("break_time")]
		public System.TimeSpan BreakTime { get; set; }
		[JsonProperty("is_over_time")]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("in_mode")]
		public int InMode { get; set; }
		[JsonProperty("out_mode")]
		public int OutMode { get; set; }
		[JsonProperty("break_count")]
		public int BreakCount { get; set; }
		[JsonProperty("check_in_expand_time")]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("check_out_expand_time")]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("store_filter")]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("come_late_expand_time")]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leave_early_expand_time")]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		//[JsonProperty("employee_group")]
		//public EmployeeGroupViewModel EmployeeGroupVM { get; set; }
		
		public TimeFrameViewModel(TimeFrame entity) : this()
		{
			FromEntity(entity);
		}
		
		public TimeFrameViewModel()
		{
		}
		
	}
}
