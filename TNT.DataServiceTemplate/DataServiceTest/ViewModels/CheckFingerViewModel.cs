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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("fingerScanMachineId")]
		public Nullable<int> FingerScanMachineId { get; set; }
		[JsonProperty("employeeId")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("dateTime")]
		public DateTime DateTime { get; set; }
		[JsonProperty("mode")]
		public Nullable<int> Mode { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("machineNumber")]
		public string MachineNumber { get; set; }
		[JsonProperty("empEnrollNumber")]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("isUpdated")]
		public Nullable<bool> IsUpdated { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("logCode")]
		public string LogCode { get; set; }
		[JsonProperty("employee")]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("fingerScanMachine")]
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
