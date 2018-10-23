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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("productCollectionId")]
		public int ProductCollectionId { get; set; }
		[JsonProperty("productId")]
		public int ProductId { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("productCollection")]
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
