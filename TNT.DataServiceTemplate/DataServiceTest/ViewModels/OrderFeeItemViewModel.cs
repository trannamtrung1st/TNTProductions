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
		[JsonProperty("order_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OrderId { get; set; }
		[JsonProperty("rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentId { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TotalAmount { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> FinalAmount { get; set; }
		[JsonProperty("order_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime OrderDate { get; set; }
		[JsonProperty("detail_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DetailDescription { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> FromDate { get; set; }
		[JsonProperty("to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ToDate { get; set; }
		[JsonProperty("is_addition", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAddition { get; set; }
		[JsonProperty("product_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("room_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("room_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RoomName { get; set; }
		[JsonProperty("rent_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentMode { get; set; }
		[JsonProperty("price_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PriceGroupId { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("price_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
