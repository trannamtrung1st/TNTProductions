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
		[JsonProperty("emp_enroll_number")]
		public string EmpEnrollNumber { get; set; }
		[JsonProperty("main_store_id")]
		public int MainStoreId { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("salary")]
		public Nullable<decimal> Salary { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("date_start_work")]
		public Nullable<DateTime> DateStartWork { get; set; }
		[JsonProperty("employee_group_id")]
		public Nullable<int> EmployeeGroupId { get; set; }
		[JsonProperty("employee_code")]
		public string EmployeeCode { get; set; }
		[JsonProperty("employee_regency")]
		public string EmployeeRegency { get; set; }
		[JsonProperty("date_of_birth")]
		public Nullable<DateTime> DateOfBirth { get; set; }
		[JsonProperty("employee_sex")]
		public Nullable<int> EmployeeSex { get; set; }
		[JsonProperty("personal_card_id")]
		public string PersonalCardId { get; set; }
		[JsonProperty("date_personal_card")]
		public Nullable<DateTime> DatePersonalCard { get; set; }
		[JsonProperty("place_of_personal_card")]
		public string PlaceOfPersonalCard { get; set; }
		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("main_address")]
		public string MainAddress { get; set; }
		[JsonProperty("employee_hometown")]
		public string EmployeeHometown { get; set; }
		[JsonProperty("employee_place_born")]
		public string EmployeePlaceBorn { get; set; }
		//[JsonProperty("employee_group")]
		//public EmployeeGroupViewModel EmployeeGroupVM { get; set; }
		//[JsonProperty("asp_net_users")]
		//public IEnumerable<AspNetUserViewModel> AspNetUsersVM { get; set; }
		//[JsonProperty("attendances")]
		//public IEnumerable<AttendanceViewModel> AttendancesVM { get; set; }
		//[JsonProperty("check_fingers")]
		//public IEnumerable<CheckFingerViewModel> CheckFingersVM { get; set; }
		//[JsonProperty("employee_fingers")]
		//public IEnumerable<EmployeeFingerViewModel> EmployeeFingersVM { get; set; }
		//[JsonProperty("employee_in_stores")]
		//public IEnumerable<EmployeeInStoreViewModel> EmployeeInStoresVM { get; set; }
		//[JsonProperty("pay_slips")]
		//public IEnumerable<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public EmployeeViewModel(Employee entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeViewModel()
		{
			//this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			//this.AttendancesVM = new HashSet<AttendanceViewModel>();
			//this.CheckFingersVM = new HashSet<CheckFingerViewModel>();
			//this.EmployeeFingersVM = new HashSet<EmployeeFingerViewModel>();
			//this.EmployeeInStoresVM = new HashSet<EmployeeInStoreViewModel>();
			//this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
