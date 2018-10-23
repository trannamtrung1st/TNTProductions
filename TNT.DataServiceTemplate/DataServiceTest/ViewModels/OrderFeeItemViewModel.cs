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
	public partial class OrderFeeItemViewModel: BaseViewModel<OrderFeeItem>
	{
		[JsonProperty("orderId")]
		public int OrderId { get; set; }
		[JsonProperty("rentId")]
		public int RentId { get; set; }
		[JsonProperty("totalAmount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("finalAmount")]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("orderDate")]
		public DateTime OrderDate { get; set; }
		[JsonProperty("detailDescription")]
		public string DetailDescription { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("customerID")]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("fromDate")]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("toDate")]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("isAddition")]
		public bool IsAddition { get; set; }
		[JsonProperty("productType")]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("roomId")]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("roomName")]
		public string RoomName { get; set; }
		[JsonProperty("rentMode")]
		public Nullable<int> RentMode { get; set; }
		[JsonProperty("priceGroupId")]
		public Nullable<int> PriceGroupId { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("priceGroup")]
		public PriceGroupViewModel PriceGroupVM { get; set; }
		
		public OrderFeeItemViewModel(OrderFeeItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderFeeItemViewModel()
		{
		}
		
	}
}
