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
	public partial class InventoryReceiptItemViewModel: BaseViewModel<InventoryReceiptItem>
	{
		[JsonProperty("receiptID")]
		public int ReceiptID { get; set; }
		[JsonProperty("itemID")]
		public int ItemID { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("dateExpired")]
		public Nullable<DateTime> DateExpired { get; set; }
		[JsonProperty("exportedDate")]
		public DateTime ExportedDate { get; set; }
		[JsonProperty("isUnit1")]
		public bool IsUnit1 { get; set; }
		[JsonProperty("inventoryReceipt")]
		public InventoryReceiptViewModel InventoryReceiptVM { get; set; }
		[JsonProperty("productItem")]
		public ProductItemViewModel ProductItemVM { get; set; }
		
		public InventoryReceiptItemViewModel(InventoryReceiptItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryReceiptItemViewModel()
		{
		}
		
	}
}
