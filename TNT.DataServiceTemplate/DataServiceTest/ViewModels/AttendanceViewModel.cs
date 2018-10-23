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
		[JsonProperty("employeeId")]
		public int EmployeeId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("checkMin")]
		public Nullable<DateTime> CheckMin { get; set; }
		[JsonProperty("checkMax")]
		public Nullable<DateTime> CheckMax { get; set; }
		[JsonProperty("totalWorkTime")]
		public Nullable<System.TimeSpan> TotalWorkTime { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("shiftMin")]
		public DateTime ShiftMin { get; set; }
		[JsonProperty("shiftMax")]
		public DateTime ShiftMax { get; set; }
		[JsonProperty("expandTime")]
		public System.TimeSpan ExpandTime { get; set; }
		[JsonProperty("updatePerson")]
		public string UpdatePerson { get; set; }
		[JsonProperty("processingStatus")]
		public Nullable<int> ProcessingStatus { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("timeFramId")]
		public int TimeFramId { get; set; }
		[JsonProperty("breakTime")]
		public Nullable<System.TimeSpan> BreakTime { get; set; }
		[JsonProperty("requestedCheckOut")]
		public Nullable<DateTime> RequestedCheckOut { get; set; }
		[JsonProperty("requestedCheckIn")]
		public Nullable<DateTime> RequestedCheckIn { get; set; }
		[JsonProperty("isRequested")]
		public Nullable<int> IsRequested { get; set; }
		[JsonProperty("approvePerson")]
		public string ApprovePerson { get; set; }
		[JsonProperty("noteRequest")]
		public string NoteRequest { get; set; }
		[JsonProperty("lastCheckBeforeShift")]
		public Nullable<DateTime> LastCheckBeforeShift { get; set; }
		[JsonProperty("firstCheckAfterShift")]
		public Nullable<DateTime> FirstCheckAfterShift { get; set; }
		[JsonProperty("isOverTime")]
		public Nullable<bool> IsOverTime { get; set; }
		[JsonProperty("inMode")]
		public Nullable<int> InMode { get; set; }
		[JsonProperty("outMode")]
		public Nullable<int> OutMode { get; set; }
		[JsonProperty("breakCount")]
		public Nullable<int> BreakCount { get; set; }
		[JsonProperty("checkInExpandTime")]
		public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
		[JsonProperty("checkOutExpandTime")]
		public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
		[JsonProperty("comeLateExpandTime")]
		public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
		[JsonProperty("leaveEarlyExpandTime")]
		public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("employee")]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("store")]
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
