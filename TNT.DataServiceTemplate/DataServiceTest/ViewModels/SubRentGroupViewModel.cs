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
	public partial class SubRentGroupViewModel: BaseViewModel<SubRentGroup>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("room_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RoomType { get; set; }
		[JsonProperty("from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime FromDate { get; set; }
		[JsonProperty("to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ToDate { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Quantity { get; set; }
		[JsonProperty("serviced_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ServicedQuantity { get; set; }
		[JsonProperty("rent_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentGroupID { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("source_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SourceId { get; set; }
		[JsonProperty("order_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderGroupViewModel OrderGroupVM { get; set; }
		[JsonProperty("room_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RoomCategoryViewModel RoomCategoryVM { get; set; }
		
		public SubRentGroupViewModel(SubRentGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public SubRentGroupViewModel()
		{
		}
		
	}
}
