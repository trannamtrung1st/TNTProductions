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
		[JsonProperty("providerProductItemId")]
		public int ProviderProductItemId { get; set; }
		[JsonProperty("providerID")]
		public int ProviderID { get; set; }
		[JsonProperty("productItemID")]
		public int ProductItemID { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("productItem")]
		public ProductItemViewModel ProductItemVM { get; set; }
		[JsonProperty("provider")]
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
