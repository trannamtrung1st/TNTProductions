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
	public partial class PromotionStoreMappingViewModel: BaseViewModel<PromotionStoreMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("promotion_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionId { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("promotion", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public PromotionStoreMappingViewModel(PromotionStoreMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionStoreMappingViewModel()
		{
		}
		
	}
}
