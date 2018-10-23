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
		[JsonProperty("categoryID")]
		public int CategoryID { get; set; }
		[JsonProperty("priceGroupID")]
		public int PriceGroupID { get; set; }
		[JsonProperty("isDefault")]
		public bool IsDefault { get; set; }
		[JsonProperty("priceGroup")]
		public PriceGroupViewModel PriceGroupVM { get; set; }
		[JsonProperty("roomCategory")]
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
