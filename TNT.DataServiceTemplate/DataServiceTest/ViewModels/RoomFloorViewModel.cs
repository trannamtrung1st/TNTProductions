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
		[JsonProperty("floor_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int FloorID { get; set; }
		[JsonProperty("floor_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FloorName { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Position { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("is_delete", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDelete { get; set; }
		[JsonProperty("rooms", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoomViewModel> RoomsVM { get; set; }
		
		public RoomFloorViewModel(RoomFloor entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomFloorViewModel()
		{
			this.RoomsVM = new HashSet<RoomViewModel>();
		}
		
	}
}
