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
		[JsonProperty("comboID")]
		public int ComboID { get; set; }
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("product1")]
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
