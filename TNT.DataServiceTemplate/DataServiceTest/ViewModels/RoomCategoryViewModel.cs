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
	public partial class RoomCategoryViewModel: BaseViewModel<RoomCategory>
	{
		[JsonProperty("categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }
		[JsonProperty("iconUrl")]
		public string IconUrl { get; set; }
		[JsonProperty("shortNane")]
		public string ShortNane { get; set; }
		[JsonProperty("priority")]
		public int Priority { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("isDelete")]
		public Nullable<bool> IsDelete { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("rooms")]
		public ICollection<RoomViewModel> RoomsVM { get; set; }
		[JsonProperty("roomCategoryPriceGroupMappings")]
		public ICollection<RoomCategoryPriceGroupMappingViewModel> RoomCategoryPriceGroupMappingsVM { get; set; }
		[JsonProperty("subRentGroups")]
		public ICollection<SubRentGroupViewModel> SubRentGroupsVM { get; set; }
		
		public RoomCategoryViewModel(RoomCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomCategoryViewModel()
		{
			this.RoomsVM = new HashSet<RoomViewModel>();
			this.RoomCategoryPriceGroupMappingsVM = new HashSet<RoomCategoryPriceGroupMappingViewModel>();
			this.SubRentGroupsVM = new HashSet<SubRentGroupViewModel>();
		}
		
	}
}
