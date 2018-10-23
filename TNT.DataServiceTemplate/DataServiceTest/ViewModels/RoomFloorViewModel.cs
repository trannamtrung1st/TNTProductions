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
		[JsonProperty("floorID")]
		public int FloorID { get; set; }
		[JsonProperty("floorName")]
		public string FloorName { get; set; }
		[JsonProperty("position")]
		public Nullable<int> Position { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("isDelete")]
		public Nullable<bool> IsDelete { get; set; }
		[JsonProperty("rooms")]
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
