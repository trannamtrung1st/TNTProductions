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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("productId")]
		public int ProductId { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("product")]
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
