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
		[JsonProperty("order_id")]
		public int OrderId { get; set; }
		[JsonProperty("rent_id")]
		public int RentId { get; set; }
		[JsonProperty("total_amount")]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount")]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("order_date")]
		public DateTime OrderDate { get; set; }
		[JsonProperty("detail_description")]
		public string DetailDescription { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("customer_id")]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("from_date")]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("to_date")]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("is_addition")]
		public bool IsAddition { get; set; }
		[JsonProperty("product_type")]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("room_id")]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("room_name")]
		public string RoomName { get; set; }
		[JsonProperty("rent_mode")]
		public Nullable<int> RentMode { get; set; }
		[JsonProperty("price_group_id")]
		public Nullable<int> PriceGroupId { get; set; }
		//[JsonProperty("order")]
		//public OrderViewModel OrderVM { get; set; }
		//[JsonProperty("price_group")]
		//public PriceGroupViewModel PriceGroupVM { get; set; }
		
		public OrderFeeItemViewModel(OrderFeeItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderFeeItemViewModel()
		{
		}
		
	}
}
