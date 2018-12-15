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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("brand_name")]
		public string BrandName { get; set; }
		[JsonProperty("create_date")]
		public DateTime CreateDate { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("company_name")]
		public string CompanyName { get; set; }
		[JsonProperty("contact_person")]
		public string ContactPerson { get; set; }
		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("website")]
		public string Website { get; set; }
		[JsonProperty("vatcode")]
		public string VATCode { get; set; }
		[JsonProperty("vattemplate")]
		public Nullable<int> VATTemplate { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("api_smskey")]
		public string ApiSMSKey { get; set; }
		[JsonProperty("security_api_smskey")]
		public string SecurityApiSMSKey { get; set; }
		[JsonProperty("smstype")]
		public Nullable<int> SMSType { get; set; }
		[JsonProperty("brand_name_sms")]
		public string BrandNameSMS { get; set; }
		[JsonProperty("json_config_url")]
		public string JsonConfigUrl { get; set; }
		[JsonProperty("brand_feature_filter")]
		public string BrandFeatureFilter { get; set; }
		[JsonProperty("wisky_id")]
		public Nullable<int> WiskyId { get; set; }
		[JsonProperty("default_dash_board")]
		public string DefaultDashBoard { get; set; }
		//[JsonProperty("partner_mappings")]
		//public IEnumerable<PartnerMappingViewModel> PartnerMappingsVM { get; set; }
		//[JsonProperty("contacts")]
		//public IEnumerable<ContactViewModel> ContactsVM { get; set; }
		//[JsonProperty("customer_filters")]
		//public IEnumerable<CustomerFilterViewModel> CustomerFiltersVM { get; set; }
		//[JsonProperty("customer_types")]
		//public IEnumerable<CustomerTypeViewModel> CustomerTypesVM { get; set; }
		//[JsonProperty("inventory_template_reports")]
		//public IEnumerable<InventoryTemplateReportViewModel> InventoryTemplateReportsVM { get; set; }
		//[JsonProperty("product_categories")]
		//public IEnumerable<ProductCategoryViewModel> ProductCategoriesVM { get; set; }
		//[JsonProperty("product_collections")]
		//public IEnumerable<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		//[JsonProperty("stores")]
		//public IEnumerable<StoreViewModel> StoresVM { get; set; }
		//[JsonProperty("store_groups")]
		//public IEnumerable<StoreGroupViewModel> StoreGroupsVM { get; set; }
		//[JsonProperty("vatorders")]
		//public IEnumerable<VATOrderViewModel> VATOrdersVM { get; set; }
		
		public BrandViewModel(Brand entity) : this()
		{
			FromEntity(entity);
		}
		
		public BrandViewModel()
		{
			//this.PartnerMappingsVM = new HashSet<PartnerMappingViewModel>();
			//this.ContactsVM = new HashSet<ContactViewModel>();
			//this.CustomerFiltersVM = new HashSet<CustomerFilterViewModel>();
			//this.CustomerTypesVM = new HashSet<CustomerTypeViewModel>();
			//this.InventoryTemplateReportsVM = new HashSet<InventoryTemplateReportViewModel>();
			//this.ProductCategoriesVM = new HashSet<ProductCategoryViewModel>();
			//this.ProductCollectionsVM = new HashSet<ProductCollectionViewModel>();
			//this.StoresVM = new HashSet<StoreViewModel>();
			//this.StoreGroupsVM = new HashSet<StoreGroupViewModel>();
			//this.VATOrdersVM = new HashSet<VATOrderViewModel>();
		}
		
	}
}
