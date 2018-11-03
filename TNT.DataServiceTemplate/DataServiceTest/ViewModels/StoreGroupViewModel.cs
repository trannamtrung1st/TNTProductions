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
		[JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int GroupID { get; set; }
		[JsonProperty("group_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string GroupName { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("brand", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("store_group_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreGroupMappingViewModel> StoreGroupMappingsVM { get; set; }
		
		public StoreGroupViewModel(StoreGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreGroupViewModel()
		{
			this.StoreGroupMappingsVM = new HashSet<StoreGroupMappingViewModel>();
		}
		
	}
}
