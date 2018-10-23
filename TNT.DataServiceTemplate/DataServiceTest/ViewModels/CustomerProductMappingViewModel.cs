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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("customerID")]
		public int CustomerID { get; set; }
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("totalQuantity")]
		public int TotalQuantity { get; set; }
		[JsonProperty("updateDate")]
		public DateTime UpdateDate { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("product")]
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
