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
		[JsonProperty("receipt_id")]
		public int ReceiptID { get; set; }
		[JsonProperty("item_id")]
		public int ItemID { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("date_expired")]
		public Nullable<DateTime> DateExpired { get; set; }
		[JsonProperty("exported_date")]
		public DateTime ExportedDate { get; set; }
		[JsonProperty("is_unit1")]
		public bool IsUnit1 { get; set; }
		//[JsonProperty("inventory_receipt")]
		//public InventoryReceiptViewModel InventoryReceiptVM { get; set; }
		//[JsonProperty("product_item")]
		//public ProductItemViewModel ProductItemVM { get; set; }
		
		public InventoryReceiptItemViewModel(InventoryReceiptItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public InventoryReceiptItemViewModel()
		{
		}
		
	}
}
