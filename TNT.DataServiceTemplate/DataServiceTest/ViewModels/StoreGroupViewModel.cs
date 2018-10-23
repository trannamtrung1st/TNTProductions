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
		[JsonProperty("groupID")]
		public int GroupID { get; set; }
		[JsonProperty("groupName")]
		public string GroupName { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("brand")]
		public BrandViewModel BrandVM { get; set; }
		[JsonProperty("storeGroupMappings")]
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
