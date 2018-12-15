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
	public partial class ProviderProductItemMappingViewModel: BaseViewModel<ProviderProductItemMapping>
	{
		[JsonProperty("provider_product_item_id")]
		public int ProviderProductItemId { get; set; }
		[JsonProperty("provider_id")]
		public int ProviderID { get; set; }
		[JsonProperty("product_item_id")]
		public int ProductItemID { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("product_item")]
		//public ProductItemViewModel ProductItemVM { get; set; }
		//[JsonProperty("provider")]
		//public ProviderViewModel ProviderVM { get; set; }
		
		public ProviderProductItemMappingViewModel(ProviderProductItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProviderProductItemMappingViewModel()
		{
		}
		
	}
}
