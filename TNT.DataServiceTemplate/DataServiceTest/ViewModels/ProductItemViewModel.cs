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
		[JsonProperty("itemID")]
		public int ItemID { get; set; }
		[JsonProperty("itemName")]
		public string ItemName { get; set; }
		[JsonProperty("unit")]
		public string Unit { get; set; }
		[JsonProperty("isAvailable")]
		public Nullable<bool> IsAvailable { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("catID")]
		public Nullable<int> CatID { get; set; }
		[JsonProperty("price")]
		public Nullable<double> Price { get; set; }
		[JsonProperty("unit2")]
		public string Unit2 { get; set; }
		[JsonProperty("unitRate")]
		public Nullable<double> UnitRate { get; set; }
		[JsonProperty("indexPriority")]
		public Nullable<int> IndexPriority { get; set; }
		[JsonProperty("createDate")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("itemType")]
		public Nullable<int> ItemType { get; set; }
		[JsonProperty("itemCode")]
		public string ItemCode { get; set; }
		[JsonProperty("productItemCategory")]
		public ProductItemCategoryViewModel ProductItemCategoryVM { get; set; }
		[JsonProperty("inventoryDateReportItems")]
		public ICollection<InventoryDateReportItemViewModel> InventoryDateReportItemsVM { get; set; }
		[JsonProperty("inventoryReceiptItems")]
		public ICollection<InventoryReceiptItemViewModel> InventoryReceiptItemsVM { get; set; }
		[JsonProperty("productItemCompositionMappings")]
		public ICollection<ProductItemCompositionMappingViewModel> ProductItemCompositionMappingsVM { get; set; }
		[JsonProperty("providerProductItemMappings")]
		public ICollection<ProviderProductItemMappingViewModel> ProviderProductItemMappingsVM { get; set; }
		[JsonProperty("templateReportProductItemMappings")]
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
