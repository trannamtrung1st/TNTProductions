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
	public partial class ProductImageViewModel: BaseViewModel<ProductImage>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductId { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		
		public ProductImageViewModel(ProductImage entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductImageViewModel()
		{
		}
		
	}
}
