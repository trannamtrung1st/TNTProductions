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
	public partial class AttendanceViewModel: BaseViewModel<Attendance>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("employee_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int EmployeeId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("check_min", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CheckMin { get; set; }
		[JsonProperty("check_max", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CheckMax { get; set; }
		[JsonProperty("total_work_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> TotalWorkTime { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("shift_min", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ShiftMin { get; set; }
		[JsonProperty("shift_max", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ShiftMax { get; set; }
		[JsonProperty("expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public System.TimeSpan ExpandTime { get; set; }
		[JsonProperty("update_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UpdatePerson { get; set; }
		[JsonProperty("processing_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProcessingStatus { get; set; }
		[JsonProperty("note", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Note { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("time_fram_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TimeFramId { get; set; }
		[JsonProperty("break_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> BreakTime { get; set; }
		[JsonProperty("requested_check_out", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> RequestedCheckOut { get; set; }
		[JsonProperty("requested_check_in", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> RequestedCheckIn { get; set; }
		[JsonProperty("is_requested", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> IsRequested { get; set; }
		[JsonProperty("approve_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApprovePerson { get; set; }
		[JsonProperty("note_request", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NoteRequest { get; set; }
		[JsonProperty("last_check_before_shift", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastCheckBeforeShift { get; set; }
		[JsonProperty("first_check_after_shift", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> FirstCheckAfterShift { get; set; }
		[JsonProperty("is_over_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("in_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> InMode { get; set; }
		[JsonProperty("out_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OutMode { get; set; }
		[JsonProperty("break_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BreakCount { get; set; }
		[JsonProperty("check_in_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("check_out_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("come_late_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leave_early_expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public AttendanceViewModel(Attendance entity) : this()
		{
			FromEntity(entity);
		}
		
		public AttendanceViewModel()
		{
		}
		
	}
}
