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
	public partial class ProductItemCompositionMappingViewModel: BaseViewModel<ProductItemCompositionMapping>
	{
		[JsonProperty("produc_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProducID { get; set; }
		[JsonProperty("item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Quantity { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("product_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductItemViewModel ProductItemVM { get; set; }
		
		public ProductItemCompositionMappingViewModel(ProductItemCompositionMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductItemCompositionMappingViewModel()
		{
		}
		
	}
}
