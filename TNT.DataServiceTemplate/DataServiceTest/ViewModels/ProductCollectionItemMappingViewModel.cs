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
	public partial class ProductCollectionItemMappingViewModel: BaseViewModel<ProductCollectionItemMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("product_collection_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductCollectionId { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductId { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("product_collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCollectionViewModel ProductCollectionVM { get; set; }
		
		public ProductCollectionItemMappingViewModel(ProductCollectionItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductCollectionItemMappingViewModel()
		{
		}
		
	}
}
