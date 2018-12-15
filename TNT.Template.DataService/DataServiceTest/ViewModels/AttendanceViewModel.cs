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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("employee_id")]
		public int EmployeeId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("check_min")]
		public Nullable<DateTime> CheckMin { get; set; }
		[JsonProperty("check_max")]
		public Nullable<DateTime> CheckMax { get; set; }
		[JsonProperty("total_work_time")]
		public Nullable<System.TimeSpan> TotalWorkTime { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("shift_min")]
		public DateTime ShiftMin { get; set; }
		[JsonProperty("shift_max")]
		public DateTime ShiftMax { get; set; }
		[JsonProperty("expand_time")]
		public System.TimeSpan ExpandTime { get; set; }
		[JsonProperty("update_person")]
		public string UpdatePerson { get; set; }
		[JsonProperty("processing_status")]
		public Nullable<int> ProcessingStatus { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("time_fram_id")]
		public int TimeFramId { get; set; }
		[JsonProperty("break_time")]
		public Nullable<System.TimeSpan> BreakTime { get; set; }
		[JsonProperty("requested_check_out")]
		public Nullable<DateTime> RequestedCheckOut { get; set; }
		[JsonProperty("requested_check_in")]
		public Nullable<DateTime> RequestedCheckIn { get; set; }
		[JsonProperty("is_requested")]
		public Nullable<int> IsRequested { get; set; }
		[JsonProperty("approve_person")]
		public string ApprovePerson { get; set; }
		[JsonProperty("note_request")]
		public string NoteRequest { get; set; }
		[JsonProperty("last_check_before_shift")]
		public Nullable<DateTime> LastCheckBeforeShift { get; set; }
		[JsonProperty("first_check_after_shift")]
		public Nullable<DateTime> FirstCheckAfterShift { get; set; }
		[JsonProperty("is_over_time")]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("in_mode")]
		public Nullable<int> InMode { get; set; }
		[JsonProperty("out_mode")]
		public Nullable<int> OutMode { get; set; }
		[JsonProperty("break_count")]
		public Nullable<int> BreakCount { get; set; }
		[JsonProperty("check_in_expand_time")]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("check_out_expand_time")]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("come_late_expand_time")]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leave_early_expand_time")]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		//[JsonProperty("employee")]
		//public EmployeeViewModel EmployeeVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public AttendanceViewModel(Attendance entity) : this()
		{
			FromEntity(entity);
		}
		
		public AttendanceViewModel()
		{
		}
		
	}
}
