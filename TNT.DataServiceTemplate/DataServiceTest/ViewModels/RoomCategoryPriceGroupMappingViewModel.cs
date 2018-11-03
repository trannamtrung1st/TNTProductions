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
	public partial class RoomCategoryPriceGroupMappingViewModel: BaseViewModel<RoomCategoryPriceGroupMapping>
	{
		[JsonProperty("category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CategoryID { get; set; }
		[JsonProperty("price_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PriceGroupID { get; set; }
		[JsonProperty("is_default", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsDefault { get; set; }
		[JsonProperty("price_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PriceGroupViewModel PriceGroupVM { get; set; }
		[JsonProperty("room_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public RoomCategoryViewModel RoomCategoryVM { get; set; }
		
		public RoomCategoryPriceGroupMappingViewModel(RoomCategoryPriceGroupMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public RoomCategoryPriceGroupMappingViewModel()
		{
		}
		
	}
}
