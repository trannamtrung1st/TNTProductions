using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class ProductViewModel: BaseViewModel<Product>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("parentId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("smallestUnit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SmallestUnit { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Price { get; set; }
		[JsonProperty("product2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel Product2VM { get; set; }
		[JsonProperty("orderItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderItemViewModel> OrderItemsVM { get; set; }
		[JsonProperty("product1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductViewModel> Product1VM { get; set; }
		
		public ProductViewModel(Product entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductViewModel()
		{
			this.OrderItemsVM = new HashSet<OrderItemViewModel>();
			this.Product1VM = new HashSet<ProductViewModel>();
		}
		
	}
}
