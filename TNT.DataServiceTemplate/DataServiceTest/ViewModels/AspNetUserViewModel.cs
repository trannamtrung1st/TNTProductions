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
		[JsonProperty("emailConfirmed")]
		public bool EmailConfirmed { get; set; }
		[JsonProperty("passwordHash")]
		public string PasswordHash { get; set; }
		[JsonProperty("securityStamp")]
		public string SecurityStamp { get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber { get; set; }
		[JsonProperty("phoneNumberConfirmed")]
		public bool PhoneNumberConfirmed { get; set; }
		[JsonProperty("twoFactorEnabled")]
		public bool TwoFactorEnabled { get; set; }
		[JsonProperty("lockoutEndDateUtc")]
		public Nullable<DateTime> LockoutEndDateUtc { get; set; }
		[JsonProperty("lockoutEnabled")]
		public bool LockoutEnabled { get; set; }
		[JsonProperty("accessFailedCount")]
		public int AccessFailedCount { get; set; }
		[JsonProperty("userName")]
		public string UserName { get; set; }
		[JsonProperty("fullName")]
		public string FullName { get; set; }
		[JsonProperty("adminStoreId")]
		public Nullable<int> AdminStoreId { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("customerId")]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("employeeId")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("employee")]
		public EmployeeViewModel EmployeeVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("aspNetRoles")]
		public AspNetRoleViewModel AspNetRolesVM { get; set; }
		[JsonProperty("aspNetUserClaims")]
		public ICollection<AspNetUserClaimViewModel> AspNetUserClaimsVM { get; set; }
		[JsonProperty("aspNetUserLogins")]
		public ICollection<AspNetUserLoginViewModel> AspNetUserLoginsVM { get; set; }
		[JsonProperty("deliveryInformations")]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("deliveryInformations1")]
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
