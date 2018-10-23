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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("storeGroupID")]
		public int StoreGroupID { get; set; }
		[JsonProperty("storeID")]
		public int StoreID { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("storeGroup")]
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
