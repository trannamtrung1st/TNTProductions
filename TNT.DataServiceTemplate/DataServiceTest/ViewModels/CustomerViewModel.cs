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
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CustomerID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; }
		[JsonProperty("contact_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContactPerson { get; set; }
		[JsonProperty("contact_person_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContactPersonNumber { get; set; }
		[JsonProperty("website", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Website { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AccountID { get; set; }
		[JsonProperty("idcard", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IDCard { get; set; }
		[JsonProperty("gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Gender { get; set; }
		[JsonProperty("birth_day", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> BirthDay { get; set; }
		[JsonProperty("store_register_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreRegisterId { get; set; }
		[JsonProperty("district", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string District { get; set; }
		[JsonProperty("city", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string City { get; set; }
		[JsonProperty("customer_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerCode { get; set; }
		[JsonProperty("customer_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerTypeId { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("delivery_info_default", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> deliveryInfoDefault { get; set; }
		[JsonProperty("pic_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string picURL { get; set; }
		[JsonProperty("account_phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AccountPhone { get; set; }
		[JsonProperty("facebook_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FacebookId { get; set; }
		[JsonProperty("partner_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PartnerId { get; set; }
		[JsonProperty("customer_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerTypeViewModel CustomerTypeVM { get; set; }
		[JsonProperty("asp_net_users", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AspNetUserViewModel> AspNetUsersVM { get; set; }
		[JsonProperty("customer_product_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerProductMappingViewModel> CustomerProductMappingsVM { get; set; }
		[JsonProperty("customer_store_report_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerStoreReportMappingViewModel> CustomerStoreReportMappingsVM { get; set; }
		[JsonProperty("delivery_infoes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeliveryInfoViewModel> DeliveryInfoesVM { get; set; }
		[JsonProperty("membership_cards", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<MembershipCardViewModel> MembershipCardsVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("order_groups", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
