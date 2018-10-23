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
		[JsonProperty("brandName")]
		public string BrandName { get; set; }
		[JsonProperty("createDate")]
		public DateTime CreateDate { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("companyName")]
		public string CompanyName { get; set; }
		[JsonProperty("contactPerson")]
		public string ContactPerson { get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("website")]
		public string Website { get; set; }
		[JsonProperty("vATCode")]
		public string VATCode { get; set; }
		[JsonProperty("vATTemplate")]
		public Nullable<int> VATTemplate { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("apiSMSKey")]
		public string ApiSMSKey { get; set; }
		[JsonProperty("securityApiSMSKey")]
		public string SecurityApiSMSKey { get; set; }
		[JsonProperty("sMSType")]
		public Nullable<int> SMSType { get; set; }
		[JsonProperty("brandNameSMS")]
		public string BrandNameSMS { get; set; }
		[JsonProperty("jsonConfigUrl")]
		public string JsonConfigUrl { get; set; }
		[JsonProperty("brandFeatureFilter")]
		public string BrandFeatureFilter { get; set; }
		[JsonProperty("wiskyId")]
		public Nullable<int> WiskyId { get; set; }
		[JsonProperty("defaultDashBoard")]
		public string DefaultDashBoard { get; set; }
		[JsonProperty("partnerMappings")]
		public ICollection<PartnerMappingViewModel> PartnerMappingsVM { get; set; }
		[JsonProperty("contacts")]
		public ICollection<ContactViewModel> ContactsVM { get; set; }
		[JsonProperty("customerFilters")]
		public ICollection<CustomerFilterViewModel> CustomerFiltersVM { get; set; }
		[JsonProperty("customerTypes")]
		public ICollection<CustomerTypeViewModel> CustomerTypesVM { get; set; }
		[JsonProperty("inventoryTemplateReports")]
		public ICollection<InventoryTemplateReportViewModel> InventoryTemplateReportsVM { get; set; }
		[JsonProperty("productCategories")]
		public ICollection<ProductCategoryViewModel> ProductCategoriesVM { get; set; }
		[JsonProperty("productCollections")]
		public ICollection<ProductCollectionViewModel> ProductCollectionsVM { get; set; }
		[JsonProperty("stores")]
		public ICollection<StoreViewModel> StoresVM { get; set; }
		[JsonProperty("storeGroups")]
		public ICollection<StoreGroupViewModel> StoreGroupsVM { get; set; }
		[JsonProperty("vATOrders")]
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
