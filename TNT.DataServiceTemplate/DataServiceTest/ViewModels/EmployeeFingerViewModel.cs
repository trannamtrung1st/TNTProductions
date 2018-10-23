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
		[JsonProperty("empId")]
		public Nullable<int> EmpId { get; set; }
		[JsonProperty("empEnrollNumber")]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("fingerIndex")]
		public int FingerIndex { get; set; }
		[JsonProperty("fingerData")]
		public string FingerData { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("nameEmployeeInMachine")]
		public string NameEmployeeInMachine { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("employee")]
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
