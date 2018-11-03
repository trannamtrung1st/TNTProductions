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
	public partial class ProductImageCollectionViewModel: BaseViewModel<ProductImageCollection>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product_image_collection_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductImageCollectionItemMappingViewModel> ProductImageCollectionItemMappingsVM { get; set; }
		
		public ProductImageCollectionViewModel(ProductImageCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductImageCollectionViewModel()
		{
			this.ProductImageCollectionItemMappingsVM = new HashSet<ProductImageCollectionItemMappingViewModel>();
		}
		
	}
}
