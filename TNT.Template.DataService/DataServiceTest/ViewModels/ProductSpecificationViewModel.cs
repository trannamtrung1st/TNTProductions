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
	public partial class ProductSpecificationViewModel: BaseViewModel<ProductSpecification>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("product_id")]
		public int ProductId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("product")]
		//public ProductViewModel ProductVM { get; set; }
		
		public ProductSpecificationViewModel(ProductSpecification entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductSpecificationViewModel()
		{
		}
		
	}
}
