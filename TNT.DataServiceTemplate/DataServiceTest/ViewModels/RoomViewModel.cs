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
	public partial class RoomViewModel: BaseViewModel<Room>
	{
		[JsonProperty("room_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RoomID { get; set; }
		[JsonProperty("room_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RoomName { get; set; }
		[JsonProperty("room_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RoomDescription { get; set; }
		[JsonProperty("room_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RoomStatus { get; set; }
		[JsonProperty("floor_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int FloorID { get; set; }
		[JsonProperty("category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CategoryID { get; set; }
		[JsonProperty("is_deleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDeleted { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("current_rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CurrentRentId { get; set; }
		[JsonProperty("rent_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("pos_x", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosX { get; set; }
		[JsonProperty("pos_span_x", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosSpanX { get; set; }
		[JsonProperty("pos_y", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosY { get; set; }
		[JsonProperty("pos_span_y", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PosSpanY { get; set; }
		[JsonProperty("rent_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentType { get; set; }
		[JsonProperty("room_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RoomCategoryViewModel RoomCategoryVM { get; set; }
		[JsonProperty("room_floor", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RoomFloorViewModel RoomFloorVM { get; set; }
		
		public RoomViewModel(Room entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomViewModel()
		{
		}
		
	}
}
