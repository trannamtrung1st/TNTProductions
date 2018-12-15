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
		[JsonProperty("produc_id")]
		public int ProducID { get; set; }
		[JsonProperty("item_id")]
		public int ItemID { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		//[JsonProperty("product")]
		//public ProductViewModel ProductVM { get; set; }
		//[JsonProperty("product_item")]
		//public ProductItemViewModel ProductItemVM { get; set; }
		
		public ProductItemCompositionMappingViewModel(ProductItemCompositionMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductItemCompositionMappingViewModel()
		{
		}
		
	}
}
