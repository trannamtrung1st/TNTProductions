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
	public partial class EmployeeViewModel: BaseViewModel<Employee>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("role")]
		public Nullable<int> Role { get; set; }
		[JsonProperty("empEnrollNumber")]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("mainStoreId")]
		public int MainStoreId { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("salary")]
		public Nullable<decimal> Salary { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("dateStartWork")]
		public Nullable<DateTime> DateStartWork { get; set; }
		[JsonProperty("employeeGroupId")]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("employeeCode")]
		public string EmployeeCode { get; set; }
		[JsonProperty("employeeRegency")]
		public string EmployeeRegency { get; set; }
		[JsonProperty("dateOfBirth")]
		public Nullable<DateTime> DateOfBirth { get; set; }
		[JsonProperty("employeeSex")]
		public Nullable<int> EmployeeSex { get; set; }
		[JsonProperty("personalCardId")]
		public string PersonalCardId { get; set; }
		[JsonProperty("datePersonalCard")]
		public Nullable<DateTime> DatePersonalCard { get; set; }
		[JsonProperty("placeOfPersonalCard")]
		public string PlaceOfPersonalCard { get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("mainAddress")]
		public string MainAddress { get; set; }
		[JsonProperty("employeeHometown")]
		public string EmployeeHometown { get; set; }
		[JsonProperty("employeePlaceBorn")]
		public string EmployeePlaceBorn { get; set; }
		[JsonProperty("employeeGroup")]
		public EmployeeGroupViewModel EmployeeGroupVM { get; set; }
		[JsonProperty("aspNetUsers")]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("attendances")]
		public ICollection<AttendanceViewModel> AttendancesVM { get; set; }
		[JsonProperty("checkFingers")]
		public ICollection<CheckFingerViewModel> CheckFingersVM { get; set; }
		[JsonProperty("employeeFingers")]
		public ICollection<EmployeeFingerViewModel> EmployeeFingersVM { get; set; }
		[JsonProperty("employeeInStores")]
		public ICollection<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		[JsonProperty("paySlips")]
		public ICollection<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public EmployeeViewModel(Employee entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeViewModel()
		{
			this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			this.AttendancesVM = new HashSet<AttendanceViewModel>();
			this.CheckFingersVM = new HashSet<CheckFingerViewModel>();
			this.EmployeeFingersVM = new HashSet<EmployeeFingerViewModel>();
			this.EmployeeInStoresVM = new HashSet<EmployeeInStoreViewModel>();
			this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
