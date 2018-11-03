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
	public partial class StoreGroupMappingViewModel: BaseViewModel<StoreGroupMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("store_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreGroupID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreID { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("store_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreGroupViewModel StoreGroupVM { get; set; }
		
		public StoreGroupMappingViewModel(StoreGroupMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreGroupMappingViewModel()
		{
		}
		
	}
}
