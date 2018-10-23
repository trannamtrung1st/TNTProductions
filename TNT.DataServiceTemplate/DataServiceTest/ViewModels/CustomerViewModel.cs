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
	public partial class CustomerViewModel: BaseViewModel<Customer>
	{
		[JsonProperty("customerID")]
		public int CustomerID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("contactPerson")]
		public string ContactPerson { get; set; }
		[JsonProperty("contactPersonNumber")]
		public string ContactPersonNumber { get; set; }
		[JsonProperty("website")]
		public string Website { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("accountID")]
		public Nullable<int> AccountID { get; set; }
		[JsonProperty("iDCard")]
		public string IDCard { get; set; }
		[JsonProperty("gender")]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("birthDay")]
		public Nullable<DateTime> BirthDay { get; set; }
		[JsonProperty("storeRegisterId")]
		public Nullable<int> StoreRegisterId { get; set; }
		[JsonProperty("district")]
		public string District { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("customerCode")]
		public string CustomerCode { get; set; }
		[JsonProperty("customerTypeId")]
		public Nullable<int> CustomerTypeId { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("deliveryInfoDefault")]
		public Nullable<int> deliveryInfoDefault { get; set; }
		[JsonProperty("picURL")]
		public string picURL { get; set; }
		[JsonProperty("accountPhone")]
		public string AccountPhone { get; set; }
		[JsonProperty("facebookId")]
		public string FacebookId { get; set; }
		[JsonProperty("partnerId")]
		public Nullable<int> PartnerId { get; set; }
		[JsonProperty("customerType")]
		public CustomerTypeViewModel CustomerTypeVM { get; set; }
		[JsonProperty("aspNetUsers")]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("customerProductMappings")]
		public ICollection<CustomerProductMappingViewModel> CustomerProductMappingsVM { get; set; }
		[JsonProperty("customerStoreReportMappings")]
		public ICollection<CustomerStoreReportMappingViewModel> CustomerStoreReportMappingsVM { get; set; }
		[JsonProperty("deliveryInfoes")]
		public ICollection<DeliveryInfoViewModel> DeliveryInfoesVM { get; set; }
		[JsonProperty("membershipCards")]
		public ICollection<MembershipCardViewModel> MembershipCardsVM { get; set; }
		[JsonProperty("orders")]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("orderGroups")]
		public ICollection<OrderGroupViewModel> OrderGroupsVM { get; set; }
		
		public CustomerViewModel(Customer entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerViewModel()
		{
			this.AspNetUsersVM = new HashSet<AspNetUserViewModel>();
			this.CustomerProductMappingsVM = new HashSet<CustomerProductMappingViewModel>();
			this.CustomerStoreReportMappingsVM = new HashSet<CustomerStoreReportMappingViewModel>();
			this.DeliveryInfoesVM = new HashSet<DeliveryInfoViewModel>();
			this.MembershipCardsVM = new HashSet<MembershipCardViewModel>();
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.OrderGroupsVM = new HashSet<OrderGroupViewModel>();
		}
		
	}
}
