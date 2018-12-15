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
		[JsonProperty("room_id")]
		public int RoomID { get; set; }
		[JsonProperty("room_name")]
		public string RoomName { get; set; }
		[JsonProperty("room_description")]
		public string RoomDescription { get; set; }
		[JsonProperty("room_status")]
		public int RoomStatus { get; set; }
		[JsonProperty("floor_id")]
		public int FloorID { get; set; }
		[JsonProperty("category_id")]
		public int CategoryID { get; set; }
		[JsonProperty("is_deleted")]
		public bool IsDeleted { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("current_rent_id")]
		public Nullable<int> CurrentRentId { get; set; }
		[JsonProperty("rent_status")]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("pos_x")]
		public int PosX { get; set; }
		[JsonProperty("pos_span_x")]
		public int PosSpanX { get; set; }
		[JsonProperty("pos_y")]
		public int PosY { get; set; }
		[JsonProperty("pos_span_y")]
		public int PosSpanY { get; set; }
		[JsonProperty("rent_type")]
		public Nullable<int> RentType { get; set; }
		//[JsonProperty("room_category")]
		//public RoomCategoryViewModel RoomCategoryVM { get; set; }
		//[JsonProperty("room_floor")]
		//public RoomFloorViewModel RoomFloorVM { get; set; }
		
		public RoomViewModel(Room entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomViewModel()
		{
		}
		
	}
}
