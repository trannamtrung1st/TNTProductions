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
	public partial class ProductComboDetailViewModel: BaseViewModel<ProductComboDetail>
	{
		[JsonProperty("combo_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ComboID { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Quantity { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("product1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel Product1VM { get; set; }
		
		public ProductComboDetailViewModel(ProductComboDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProductComboDetailViewModel()
		{
		}
		
	}
}
