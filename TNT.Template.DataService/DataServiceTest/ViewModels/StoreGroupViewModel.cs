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
	public partial class StoreGroupViewModel: BaseViewModel<StoreGroup>
	{
		[JsonProperty("group_id")]
		public int GroupID { get; set; }
		[JsonProperty("group_name")]
		public string GroupName { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		//[JsonProperty("brand")]
		//public BrandViewModel BrandVM { get; set; }
		//[JsonProperty("store_group_mappings")]
		//public IEnumerable<StoreGroupMappingViewModel> StoreGroupMappingsVM { get; set; }
		
		public StoreGroupViewModel(StoreGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreGroupViewModel()
		{
			//this.StoreGroupMappingsVM = new HashSet<StoreGroupMappingViewModel>();
		}
		
	}
}
