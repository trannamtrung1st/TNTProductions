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
	public partial class ProductImageCollectionItemMappingViewModel: BaseViewModel<ProductImageCollectionItemMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("image_collection_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ImageCollectionId { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("product_image_collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductImageCollectionViewModel ProductImageCollectionVM { get; set; }
		
		public ProductImageCollectionItemMappingViewModel(ProductImageCollectionItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductImageCollectionItemMappingViewModel()
		{
		}
		
	}
}
