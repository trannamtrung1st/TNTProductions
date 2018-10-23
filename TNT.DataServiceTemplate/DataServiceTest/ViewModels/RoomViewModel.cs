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
		[JsonProperty("roomID")]
		public int RoomID { get; set; }
		[JsonProperty("roomName")]
		public string RoomName { get; set; }
		[JsonProperty("roomDescription")]
		public string RoomDescription { get; set; }
		[JsonProperty("roomStatus")]
		public int RoomStatus { get; set; }
		[JsonProperty("floorID")]
		public int FloorID { get; set; }
		[JsonProperty("categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty("isDeleted")]
		public bool IsDeleted { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("currentRentId")]
		public Nullable<int> CurrentRentId { get; set; }
		[JsonProperty("rentStatus")]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("posX")]
		public int PosX { get; set; }
		[JsonProperty("posSpanX")]
		public int PosSpanX { get; set; }
		[JsonProperty("posY")]
		public int PosY { get; set; }
		[JsonProperty("posSpanY")]
		public int PosSpanY { get; set; }
		[JsonProperty("rentType")]
		public Nullable<int> RentType { get; set; }
		[JsonProperty("roomCategory")]
		public RoomCategoryViewModel RoomCategoryVM { get; set; }
		[JsonProperty("roomFloor")]
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
