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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("emp_id")]
		public Nullable<int> EmpId { get; set; }
		[JsonProperty("emp_enroll_number")]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("finger_index")]
		public int FingerIndex { get; set; }
		[JsonProperty("finger_data")]
		public string FingerData { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("name_employee_in_machine")]
		public string NameEmployeeInMachine { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("employee")]
		//public EmployeeViewModel EmployeeVM { get; set; }
		
		public EmployeeFingerViewModel(EmployeeFinger entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeFingerViewModel()
		{
		}
		
	}
}
