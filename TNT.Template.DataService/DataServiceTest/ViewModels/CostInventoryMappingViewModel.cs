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
		[JsonProperty("cost_id")]
		public int CostID { get; set; }
		[JsonProperty("receipt_id")]
		public int ReceiptID { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("provider_id")]
		public Nullable<int> ProviderID { get; set; }
		//[JsonProperty("cost")]
		//public CostViewModel CostVM { get; set; }
		//[JsonProperty("inventory_receipt")]
		//public InventoryReceiptViewModel InventoryReceiptVM { get; set; }
		
		public CostInventoryMappingViewModel(CostInventoryMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostInventoryMappingViewModel()
		{
		}
		
	}
}
