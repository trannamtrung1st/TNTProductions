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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("productImageCollectionItemMappings")]
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
