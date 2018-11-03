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
		[JsonProperty("category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CategoryID { get; set; }
		[JsonProperty("category_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CategoryName { get; set; }
		[JsonProperty("icon_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IconUrl { get; set; }
		[JsonProperty("short_nane", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ShortNane { get; set; }
		[JsonProperty("priority", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Priority { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("is_delete", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDelete { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("rooms", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoomViewModel> RoomsVM { get; set; }
		[JsonProperty("room_category_price_group_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<RoomCategoryPriceGroupMappingViewModel> RoomCategoryPriceGroupMappingsVM { get; set; }
		[JsonProperty("sub_rent_groups", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
