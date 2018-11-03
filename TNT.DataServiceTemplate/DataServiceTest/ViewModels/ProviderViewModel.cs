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
	public partial class ProviderViewModel: BaseViewModel<Provider>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("provider_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProviderName { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsAvailable { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("manager_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ManagerName { get; set; }
		[JsonProperty("license", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string License { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("vatcode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VATCode { get; set; }
		[JsonProperty("account_no", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AccountNo { get; set; }
		[JsonProperty("inventory_receipts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptViewModel> InventoryReceiptsVM { get; set; }
		[JsonProperty("provider_product_item_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProviderProductItemMappingViewModel> ProviderProductItemMappingsVM { get; set; }
		[JsonProperty("vatorders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VATOrderViewModel> VATOrdersVM { get; set; }
		
		public ProviderViewModel(Provider entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProviderViewModel()
		{
			this.InventoryReceiptsVM = new HashSet<InventoryReceiptViewModel>();
			this.ProviderProductItemMappingsVM = new HashSet<ProviderProductItemMappingViewModel>();
			this.VATOrdersVM = new HashSet<VATOrderViewModel>();
		}
		
	}
}
