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
	public partial class RoomFloorViewModel: BaseViewModel<RoomFloor>
	{
		[JsonProperty("floor_id")]
		public int FloorID { get; set; }
		[JsonProperty("floor_name")]
		public string FloorName { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("is_delete")]
		public Nullable<bool> IsDelete { get; set; }
		//[JsonProperty("rooms")]
		//public IEnumerable<RoomViewModel> RoomsVM { get; set; }
		
		public RoomFloorViewModel(RoomFloor entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomFloorViewModel()
		{
			//this.RoomsVM = new HashSet<RoomViewModel>();
		}
		
	}
}
