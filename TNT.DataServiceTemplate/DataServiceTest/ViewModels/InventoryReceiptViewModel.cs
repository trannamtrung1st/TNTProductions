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
	public partial class InventoryReceiptViewModel: BaseViewModel<InventoryReceipt>
	{
		[JsonProperty("receipt_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ReceiptID { get; set; }
		[JsonProperty("change_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ChangeDate { get; set; }
		[JsonProperty("receipt_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ReceiptType { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("notes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Notes { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("creator", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Creator { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("in_store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> InStoreId { get; set; }
		[JsonProperty("out_store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OutStoreId { get; set; }
		[JsonProperty("provider_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProviderId { get; set; }
		[JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("invoice_number", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string InvoiceNumber { get; set; }
		[JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Amount { get; set; }
		[JsonProperty("start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("end_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("provider", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProviderViewModel ProviderVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("store1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel Store1VM { get; set; }
		[JsonProperty("store2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel Store2VM { get; set; }
		[JsonProperty("cost_inventory_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CostInventoryMappingViewModel> CostInventoryMappingsVM { get; set; }
		[JsonProperty("inventory_receipt_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<InventoryReceiptItemViewModel> InventoryReceiptItemsVM { get; set; }
		
		public InventoryReceiptViewModel(InventoryReceipt entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryReceiptViewModel()
		{
			this.CostInventoryMappingsVM = new HashSet<CostInventoryMappingViewModel>();
			this.InventoryReceiptItemsVM = new HashSet<InventoryReceiptItemViewModel>();
		}
		
	}
}
