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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("productId")]
		public int ProductId { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("finalAmount")]
		public double FinalAmount { get; set; }
		[JsonProperty("categoryId_")]
		public Nullable<int> CategoryId_ { get; set; }
		[JsonProperty("productName_")]
		public string ProductName_ { get; set; }
		[JsonProperty("time0Quantity")]
		public Nullable<int> Time0Quantity { get; set; }
		[JsonProperty("time1Quantity")]
		public Nullable<int> Time1Quantity { get; set; }
		[JsonProperty("time2Quantity")]
		public Nullable<int> Time2Quantity { get; set; }
		[JsonProperty("time3Quantity")]
		public Nullable<int> Time3Quantity { get; set; }
		[JsonProperty("time4Quantity")]
		public Nullable<int> Time4Quantity { get; set; }
		[JsonProperty("time5Quantity")]
		public Nullable<int> Time5Quantity { get; set; }
		[JsonProperty("time6Quantity")]
		public Nullable<int> Time6Quantity { get; set; }
		[JsonProperty("time7Quantity")]
		public Nullable<int> Time7Quantity { get; set; }
		[JsonProperty("time8Quantity")]
		public Nullable<int> Time8Quantity { get; set; }
		[JsonProperty("time9Quantity")]
		public Nullable<int> Time9Quantity { get; set; }
		[JsonProperty("time10Quantity")]
		public Nullable<int> Time10Quantity { get; set; }
		[JsonProperty("time11Quantity")]
		public Nullable<int> Time11Quantity { get; set; }
		[JsonProperty("time12Quantity")]
		public Nullable<int> Time12Quantity { get; set; }
		[JsonProperty("time13Quantity")]
		public Nullable<int> Time13Quantity { get; set; }
		[JsonProperty("time14Quantity")]
		public Nullable<int> Time14Quantity { get; set; }
		[JsonProperty("time15Quantity")]
		public Nullable<int> Time15Quantity { get; set; }
		[JsonProperty("time16Quantity")]
		public Nullable<int> Time16Quantity { get; set; }
		[JsonProperty("time17Quantity")]
		public Nullable<int> Time17Quantity { get; set; }
		[JsonProperty("time18Quantity")]
		public Nullable<int> Time18Quantity { get; set; }
		[JsonProperty("time19Quantity")]
		public Nullable<int> Time19Quantity { get; set; }
		[JsonProperty("time20Quantity")]
		public Nullable<int> Time20Quantity { get; set; }
		[JsonProperty("time21Quantity")]
		public Nullable<int> Time21Quantity { get; set; }
		[JsonProperty("time22Quantity")]
		public Nullable<int> Time22Quantity { get; set; }
		[JsonProperty("time23Quantity")]
		public Nullable<int> Time23Quantity { get; set; }
		[JsonProperty("orderQuantity")]
		public Nullable<int> OrderQuantity { get; set; }
		[JsonProperty("quantityAtStore")]
		public Nullable<int> QuantityAtStore { get; set; }
		[JsonProperty("quantityTakeAway")]
		public Nullable<int> QuantityTakeAway { get; set; }
		[JsonProperty("quantityDelivery")]
		public Nullable<int> QuantityDelivery { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		
		public DateProductViewModel(DateProduct entity) : this()
		{
			FromEntity(entity);
		}
		
		public DateProductViewModel()
		{
		}
		
	}
}
