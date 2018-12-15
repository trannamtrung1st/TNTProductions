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
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("product_item_id")]
		public int ProductItemID { get; set; }
		[JsonProperty("product_item_name")]
		public string ProductItemName { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("unit")]
		public string Unit { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public DateProductItemViewModel(DateProductItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateProductItemViewModel()
		{
		}
		
	}
}
