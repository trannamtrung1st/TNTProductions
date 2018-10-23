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
		[JsonProperty("receiptID")]
		public int ReceiptID { get; set; }
		[JsonProperty("changeDate")]
		public DateTime ChangeDate { get; set; }
		[JsonProperty("receiptType")]
		public int ReceiptType { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("creator")]
		public string Creator { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("inStoreId")]
		public Nullable<int> InStoreId { get; set; }
		[JsonProperty("outStoreId")]
		public Nullable<int> OutStoreId { get; set; }
		[JsonProperty("providerId")]
		public Nullable<int> ProviderId { get; set; }
		[JsonProperty("createDate")]
		public Nullable<DateTime> CreateDate { get; set; }
		[JsonProperty("invoiceNumber")]
		public string InvoiceNumber { get; set; }
		[JsonProperty("amount")]
		public Nullable<double> Amount { get; set; }
		[JsonProperty("startDate")]
		public Nullable<DateTime> StartDate { get; set; }
		[JsonProperty("endDate")]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("provider")]
		public ProviderViewModel ProviderVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("store1")]
		public StoreViewModel Store1VM { get; set; }
		[JsonProperty("store2")]
		public StoreViewModel Store2VM { get; set; }
		[JsonProperty("costInventoryMappings")]
		public ICollection<CostInventoryMappingViewModel> CostInventoryMappingsVM { get; set; }
		[JsonProperty("inventoryReceiptItems")]
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
