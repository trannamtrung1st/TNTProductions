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
	public partial class DateProductViewModel: BaseViewModel<DateProduct>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("product_id")]
		public int ProductId { get; set; }
		[JsonProperty("store_id")]
		public int StoreID { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("total_amount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("final_amount")]
		public double FinalAmount { get; set; }
		[JsonProperty("category_id__")]
		public Nullable<int> CategoryId_ { get; set; }
		[JsonProperty("product_name__")]
		public string ProductName_ { get; set; }
		[JsonProperty("time0_quantity")]
		public Nullable<int> Time0Quantity { get; set; }
		[JsonProperty("time1_quantity")]
		public Nullable<int> Time1Quantity { get; set; }
		[JsonProperty("time2_quantity")]
		public Nullable<int> Time2Quantity { get; set; }
		[JsonProperty("time3_quantity")]
		public Nullable<int> Time3Quantity { get; set; }
		[JsonProperty("time4_quantity")]
		public Nullable<int> Time4Quantity { get; set; }
		[JsonProperty("time5_quantity")]
		public Nullable<int> Time5Quantity { get; set; }
		[JsonProperty("time6_quantity")]
		public Nullable<int> Time6Quantity { get; set; }
		[JsonProperty("time7_quantity")]
		public Nullable<int> Time7Quantity { get; set; }
		[JsonProperty("time8_quantity")]
		public Nullable<int> Time8Quantity { get; set; }
		[JsonProperty("time9_quantity")]
		public Nullable<int> Time9Quantity { get; set; }
		[JsonProperty("time10_quantity")]
		public Nullable<int> Time10Quantity { get; set; }
		[JsonProperty("time11_quantity")]
		public Nullable<int> Time11Quantity { get; set; }
		[JsonProperty("time12_quantity")]
		public Nullable<int> Time12Quantity { get; set; }
		[JsonProperty("time13_quantity")]
		public Nullable<int> Time13Quantity { get; set; }
		[JsonProperty("time14_quantity")]
		public Nullable<int> Time14Quantity { get; set; }
		[JsonProperty("time15_quantity")]
		public Nullable<int> Time15Quantity { get; set; }
		[JsonProperty("time16_quantity")]
		public Nullable<int> Time16Quantity { get; set; }
		[JsonProperty("time17_quantity")]
		public Nullable<int> Time17Quantity { get; set; }
		[JsonProperty("time18_quantity")]
		public Nullable<int> Time18Quantity { get; set; }
		[JsonProperty("time19_quantity")]
		public Nullable<int> Time19Quantity { get; set; }
		[JsonProperty("time20_quantity")]
		public Nullable<int> Time20Quantity { get; set; }
		[JsonProperty("time21_quantity")]
		public Nullable<int> Time21Quantity { get; set; }
		[JsonProperty("time22_quantity")]
		public Nullable<int> Time22Quantity { get; set; }
		[JsonProperty("time23_quantity")]
		public Nullable<int> Time23Quantity { get; set; }
		[JsonProperty("order_quantity")]
		public Nullable<int> OrderQuantity { get; set; }
		[JsonProperty("quantity_at_store")]
		public Nullable<int> QuantityAtStore { get; set; }
		[JsonProperty("quantity_take_away")]
		public Nullable<int> QuantityTakeAway { get; set; }
		[JsonProperty("quantity_delivery")]
		public Nullable<int> QuantityDelivery { get; set; }
		//[JsonProperty("product")]
		//public ProductViewModel ProductVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public DateProductViewModel(DateProduct entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateProductViewModel()
		{
		}
		
	}
}
