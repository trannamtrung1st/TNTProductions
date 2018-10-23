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
	public partial class CostInventoryMappingViewModel: BaseViewModel<CostInventoryMapping>
	{
		[JsonProperty("costID")]
		public int CostID { get; set; }
		[JsonProperty("receiptID")]
		public int ReceiptID { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("providerID")]
		public Nullable<int> ProviderID { get; set; }
		[JsonProperty("cost")]
		public CostViewModel CostVM { get; set; }
		[JsonProperty("inventoryReceipt")]
		public InventoryReceiptViewModel InventoryReceiptVM { get; set; }
		
		public CostInventoryMappingViewModel(CostInventoryMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostInventoryMappingViewModel()
		{
		}
		
	}
}
