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
	public partial class EmployeeFingerViewModel: BaseViewModel<EmployeeFinger>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("emp_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmpId { get; set; }
		[JsonProperty("emp_enroll_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("finger_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int FingerIndex { get; set; }
		[JsonProperty("finger_data", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FingerData { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("name_employee_in_machine", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NameEmployeeInMachine { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeViewModel EmployeeVM { get; set; }
		
		public EmployeeFingerViewModel(EmployeeFinger entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeFingerViewModel()
		{
		}
		
	}
}
