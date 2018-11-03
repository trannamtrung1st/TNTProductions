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
	public partial class BrandViewModel: BaseViewModel<Brand>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("brand_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BrandName { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreateDate { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("company_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CompanyName { get; set; }
		[JsonProperty("contact_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContactPerson { get; set; }
		[JsonProperty("phone_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PhoneNumber { get; set; }
		[JsonProperty("fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; }
		[JsonProperty("website", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Website { get; set; }
		[JsonProperty("vatcode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VATCode { get; set; }
		[JsonProperty("vattemplate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> VATTemplate { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("api_smskey", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApiSMSKey { get; set; }
		[JsonProperty("security_api_smskey", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SecurityApiSMSKey { get; set; }
		[JsonProperty("smstype", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SMSType { get; set; }
		[JsonProperty("brand_name_sms", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BrandNameSMS { get; set; }
		[JsonProperty("json_config_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string JsonConfigUrl { get; set; }
		[JsonProperty("brand_feature_filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BrandFeatureFilter { get; set; }
		[JsonProperty("wisky_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> WiskyId { get; set; }
		[JsonProperty("default_dash_board", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DefaultDashBoard { get; set; }
		[JsonProperty("partner_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PartnerMappingViewModel> PartnerMappingsVM { get; set; }
		[JsonProperty("contacts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ContactViewModel> ContactsVM { get; set; }
		[JsonProperty("customer_filters", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerFilterViewModel> CustomerFiltersVM { get; set; }
		[JsonProperty("customer_types", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CustomerTypeViewModel> CustomerTypesVM { get; set; }
		[JsonProperty("inventory_template_reports", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryTemplateReportViewModel> InventoryTemplateReportsVM { get; set; }
		[JsonProperty("product_categories", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCategoryViewModel> ProductCategoriesVM { get; set; }
		[JsonProperty("product_collections", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		[JsonProperty("stores", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreViewModel> StoresVM { get; set; }
		[JsonProperty("store_groups", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreGroupViewModel> StoreGroupsVM { get; set; }
		[JsonProperty("vatorders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VATOrderViewModel> VATOrdersVM { get; set; }
		
		public BrandViewModel(Brand entity) : this()
		{
			FromEntity(entity);
		}
		
		public BrandViewModel()
		{
			this.PartnerMappingsVM = new HashSet<PartnerMappingViewModel>();
			this.ContactsVM = new HashSet<ContactViewModel>();
			this.CustomerFiltersVM = new HashSet<CustomerFilterViewModel>();
			this.CustomerTypesVM = new HashSet<CustomerTypeViewModel>();
			this.InventoryTemplateReportsVM = new HashSet<InventoryTemplateReportViewModel>();
			this.ProductCategoriesVM = new HashSet<ProductCategoryViewModel>();
			this.ProductCollectionsVM = new HashSet<ProductCollectionViewModel>();
			this.StoresVM = new HashSet<StoreViewModel>();
			this.StoreGroupsVM = new HashSet<StoreGroupViewModel>();
			this.VATOrdersVM = new HashSet<VATOrderViewModel>();
		}
		
	}
}
