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
	public partial class DateProductItemViewModel: BaseViewModel<DateProductItem>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("product_item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductItemID { get; set; }
		[JsonProperty("product_item_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductItemName { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Quantity { get; set; }
		[JsonProperty("unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Unit { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public DateProductItemViewModel(DateProductItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateProductItemViewModel()
		{
		}
		
	}
}
