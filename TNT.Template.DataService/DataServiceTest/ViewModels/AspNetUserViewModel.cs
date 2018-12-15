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
	public partial class AspNetUserViewModel: BaseViewModel<AspNetUser>
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("email_confirmed")]
		public bool EmailConfirmed { get; set; }
		[JsonProperty("password_hash")]
		public string PasswordHash { get; set; }
		[JsonProperty("security_stamp")]
		public string SecurityStamp { get; set; }
		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }
		[JsonProperty("phone_number_confirmed")]
		public bool PhoneNumberConfirmed { get; set; }
		[JsonProperty("two_factor_enabled")]
		public bool TwoFactorEnabled { get; set; }
		[JsonProperty("lockout_end_date_utc")]
		public Nullable<DateTime> LockoutEndDateUtc { get; set; }
		[JsonProperty("lockout_enabled")]
		public bool LockoutEnabled { get; set; }
		[JsonProperty("access_failed_count")]
		public int AccessFailedCount { get; set; }
		[JsonProperty("user_name")]
		public string UserName { get; set; }
		[JsonProperty("full_name")]
		public string FullName { get; set; }
		[JsonProperty("admin_store_id")]
		public Nullable<int> AdminStoreId { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("customer_id")]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("employee_id")]
		public Nullable<int> EmployeeId { get; set; }
		//[JsonProperty("customer")]
		//public CustomerViewModel CustomerVM { get; set; }
		//[JsonProperty("employee")]
		//public EmployeeViewModel EmployeeVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("asp_net_roles")]
		//public AspNetRoleViewModel AspNetRolesVM { get; set; }
		//[JsonProperty("asp_net_user_claims")]
		//public IEnumerable<AspNetUserClaimViewModel> AspNetUserClaimsVM { get; set; }
		//[JsonProperty("asp_net_user_logins")]
		//public IEnumerable<AspNetUserLoginViewModel> AspNetUserLoginsVM { get; set; }
		//[JsonProperty("delivery_informations")]
		//public IEnumerable<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		//[JsonProperty("delivery_informations1")]
		//public IEnumerable<DeliveryInformationViewModel> DeliveryInformations1VM { get; set; }
		
		public AspNetUserViewModel(AspNetUser entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetUserViewModel()
		{
			//this.AspNetUserClaimsVM = new HashSet<AspNetUserClaimViewModel>();
			//this.AspNetUserLoginsVM = new HashSet<AspNetUserLoginViewModel>();
			//this.DeliveryInformationsVM = new HashSet<DeliveryInformationViewModel>();
			//this.DeliveryInformations1VM = new HashSet<DeliveryInformationViewModel>();
		}
		
	}
}
