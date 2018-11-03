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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Id { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("email_confirmed", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool EmailConfirmed { get; set; }
		[JsonProperty("password_hash", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PasswordHash { get; set; }
		[JsonProperty("security_stamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SecurityStamp { get; set; }
		[JsonProperty("phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PhoneNumber { get; set; }
		[JsonProperty("phone_number_confirmed", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool PhoneNumberConfirmed { get; set; }
		[JsonProperty("two_factor_enabled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool TwoFactorEnabled { get; set; }
		[JsonProperty("lockout_end_date_utc", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LockoutEndDateUtc { get; set; }
		[JsonProperty("lockout_enabled", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool LockoutEnabled { get; set; }
		[JsonProperty("access_failed_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int AccessFailedCount { get; set; }
		[JsonProperty("user_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty("full_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FullName { get; set; }
		[JsonProperty("admin_store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AdminStoreId { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("employee_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("employee", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("asp_net_roles", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetRoleViewModel AspNetRolesVM { get; set; }
		[JsonProperty("asp_net_user_claims", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserClaimViewModel> AspNetUserClaimsVM { get; set; }
		[JsonProperty("asp_net_user_logins", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserLoginViewModel> AspNetUserLoginsVM { get; set; }
		[JsonProperty("delivery_informations", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("delivery_informations1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeliveryInformationViewModel> DeliveryInformations1VM { get; set; }
		
		public AspNetUserViewModel(AspNetUser entity) : this()
		{
			FromEntity(entity);
		}
		
		public AspNetUserViewModel()
		{
			this.AspNetUserClaimsVM = new HashSet<AspNetUserClaimViewModel>();
			this.AspNetUserLoginsVM = new HashSet<AspNetUserLoginViewModel>();
			this.DeliveryInformationsVM = new HashSet<DeliveryInformationViewModel>();
			this.DeliveryInformations1VM = new HashSet<DeliveryInformationViewModel>();
		}
		
	}
}
