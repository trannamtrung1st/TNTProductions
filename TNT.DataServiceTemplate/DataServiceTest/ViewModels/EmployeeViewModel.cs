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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("role", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Role { get; set; }
		[JsonProperty("emp_enroll_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("main_store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MainStoreId { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("salary", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> Salary { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("date_start_work", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateStartWork { get; set; }
		[JsonProperty("employee_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("employee_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmployeeCode { get; set; }
		[JsonProperty("employee_regency", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmployeeRegency { get; set; }
		[JsonProperty("date_of_birth", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateOfBirth { get; set; }
		[JsonProperty("employee_sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeSex { get; set; }
		[JsonProperty("personal_card_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PersonalCardId { get; set; }
		[JsonProperty("date_personal_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DatePersonalCard { get; set; }
		[JsonProperty("place_of_personal_card", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PlaceOfPersonalCard { get; set; }
		[JsonProperty("phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PhoneNumber { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("main_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MainAddress { get; set; }
		[JsonProperty("employee_hometown", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmployeeHometown { get; set; }
		[JsonProperty("employee_place_born", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EmployeePlaceBorn { get; set; }
		[JsonProperty("employee_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeGroupViewModel EmployeeGroupVM { get; set; }
		[JsonProperty("asp_net_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("attendances", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AttendanceViewModel> AttendancesVM { get; set; }
		[JsonProperty("check_fingers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CheckFingerViewModel> CheckFingersVM { get; set; }
		[JsonProperty("employee_fingers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EmployeeFingerViewModel> EmployeeFingersVM { get; set; }
		[JsonProperty("employee_in_stores", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		[JsonProperty("pay_slips", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
