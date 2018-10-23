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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("providerName")]
		public string ProviderName { get; set; }
		[JsonProperty("isAvailable")]
		public Nullable<bool> IsAvailable { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("managerName")]
		public string ManagerName { get; set; }
		[JsonProperty("license")]
		public string License { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("vATCode")]
		public string VATCode { get; set; }
		[JsonProperty("accountNo")]
		public string AccountNo { get; set; }
		[JsonProperty("inventoryReceipts")]
		public ICollection<InventoryReceiptViewModel> InventoryReceiptsVM { get; set; }
		[JsonProperty("providerProductItemMappings")]
		public ICollection<ProviderProductItemMappingViewModel> ProviderProductItemMappingsVM { get; set; }
		[JsonProperty("vATOrders")]
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
