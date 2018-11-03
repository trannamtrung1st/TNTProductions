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
		[JsonProperty("provider_product_item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProviderProductItemId { get; set; }
		[JsonProperty("provider_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProviderID { get; set; }
		[JsonProperty("product_item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductItemID { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductItemViewModel ProductItemVM { get; set; }
		[JsonProperty("provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProviderViewModel ProviderVM { get; set; }
		
		public ProviderProductItemMappingViewModel(ProviderProductItemMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProviderProductItemMappingViewModel()
		{
		}
		
	}
}
