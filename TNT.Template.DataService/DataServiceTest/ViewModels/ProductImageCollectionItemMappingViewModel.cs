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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("image_collection_id")]
		public int ImageCollectionId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		//[JsonProperty("product_image_collection")]
		//public ProductImageCollectionViewModel ProductImageCollectionVM { get; set; }
		
		public ProductImageCollectionItemMappingViewModel(ProductImageCollectionItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductImageCollectionItemMappingViewModel()
		{
		}
		
	}
}
