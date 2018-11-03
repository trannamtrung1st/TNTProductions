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
	public partial class ProductItemViewModel: BaseViewModel<ProductItem>
	{
		[JsonProperty("item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemID { get; set; }
		[JsonProperty("item_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ItemName { get; set; }
		[JsonProperty("unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Unit { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsAvailable { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("cat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CatID { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Price { get; set; }
		[JsonProperty("unit2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Unit2 { get; set; }
		[JsonProperty("unit_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> UnitRate { get; set; }
		[JsonProperty("index_priority", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> IndexPriority { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("item_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ItemType { get; set; }
		[JsonProperty("item_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ItemCode { get; set; }
		[JsonProperty("product_item_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductItemCategoryViewModel ProductItemCategoryVM { get; set; }
		[JsonProperty("inventory_date_report_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryDateReportItemViewModel> InventoryDateReportItemsVM { get; set; }
		[JsonProperty("inventory_receipt_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptItemViewModel> InventoryReceiptItemsVM { get; set; }
		[JsonProperty("product_item_composition_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductItemCompositionMappingViewModel> ProductItemCompositionMappingsVM { get; set; }
		[JsonProperty("provider_product_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProviderProductItemMappingViewModel> ProviderProductItemMappingsVM { get; set; }
		[JsonProperty("template_report_product_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TemplateReportProductItemMappingViewModel> TemplateReportProductItemMappingsVM { get; set; }
		
		public ProductItemViewModel(ProductItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductItemViewModel()
		{
			this.InventoryDateReportItemsVM = new HashSet<InventoryDateReportItemViewModel>();
			this.InventoryReceiptItemsVM = new HashSet<InventoryReceiptItemViewModel>();
			this.ProductItemCompositionMappingsVM = new HashSet<ProductItemCompositionMappingViewModel>();
			this.ProviderProductItemMappingsVM = new HashSet<ProviderProductItemMappingViewModel>();
			this.TemplateReportProductItemMappingsVM = new HashSet<TemplateReportProductItemMappingViewModel>();
		}
		
	}
}
