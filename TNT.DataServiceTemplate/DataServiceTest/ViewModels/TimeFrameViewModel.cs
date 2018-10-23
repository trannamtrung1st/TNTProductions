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
		[JsonProperty("startTime")]
		public System.TimeSpan StartTime { get; set; }
		[JsonProperty("endTime")]
		public System.TimeSpan EndTime { get; set; }
		[JsonProperty("duration")]
		public System.TimeSpan Duration { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("employeeGroupId")]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("breakTime")]
		public System.TimeSpan BreakTime { get; set; }
		[JsonProperty("isOverTime")]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("inMode")]
		public int InMode { get; set; }
		[JsonProperty("outMode")]
		public int OutMode { get; set; }
		[JsonProperty("breakCount")]
		public int BreakCount { get; set; }
		[JsonProperty("checkInExpandTime")]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("checkOutExpandTime")]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("storeFilter")]
		public Nullable<int> StoreFilter { get; set; }
		[JsonProperty("comeLateExpandTime")]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leaveEarlyExpandTime")]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		[JsonProperty("employeeGroup")]
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
