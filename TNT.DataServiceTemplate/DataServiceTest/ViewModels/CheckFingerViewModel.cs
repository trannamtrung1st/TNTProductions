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
	public partial class CheckFingerViewModel: BaseViewModel<CheckFinger>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("finger_scan_machine_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> FingerScanMachineId { get; set; }
		[JsonProperty("employee_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("date_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime DateTime { get; set; }
		[JsonProperty("mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Mode { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("machine_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MachineNumber { get; set; }
		[JsonProperty("emp_enroll_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("is_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsUpdated { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("log_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LogCode { get; set; }
		[JsonProperty("employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("finger_scan_machine", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public FingerScanMachineViewModel FingerScanMachineVM { get; set; }
		
		public CheckFingerViewModel(CheckFinger entity) : this()
		{
			FromEntity(entity);
		}
		
		public CheckFingerViewModel()
		{
		}
		
	}
}
