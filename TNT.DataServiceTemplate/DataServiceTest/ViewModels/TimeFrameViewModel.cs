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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("start_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan StartTime { get; set; }
		[JsonProperty("end_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan EndTime { get; set; }
		[JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan Duration { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("employee_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("break_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan BreakTime { get; set; }
		[JsonProperty("is_over_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("in_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InMode { get; set; }
		[JsonProperty("out_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OutMode { get; set; }
		[JsonProperty("break_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BreakCount { get; set; }
		[JsonProperty("check_in_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("check_out_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("store_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("come_late_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leave_early_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		[JsonProperty("employee_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeGroupViewModel EmployeeGroupVM { get; set; }
		
		public TimeFrameViewModel(TimeFrame entity) : this()
		{
			FromEntity(entity);
		}
		
		public TimeFrameViewModel()
		{
		}
		
	}
}
