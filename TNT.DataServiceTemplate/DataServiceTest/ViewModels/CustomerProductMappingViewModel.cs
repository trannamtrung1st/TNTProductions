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
	public partial class CustomerProductMappingViewModel: BaseViewModel<CustomerProductMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CustomerID { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductID { get; set; }
		[JsonProperty("total_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalQuantity { get; set; }
		[JsonProperty("update_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime UpdateDate { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		
		public CustomerProductMappingViewModel(CustomerProductMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CustomerProductMappingViewModel()
		{
		}
		
	}
}
