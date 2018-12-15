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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("promotion_id")]
		public int PromotionId { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("promotion")]
		//public PromotionViewModel PromotionVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		
		public PromotionStoreMappingViewModel(PromotionStoreMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public PromotionStoreMappingViewModel()
		{
		}
		
	}
}
