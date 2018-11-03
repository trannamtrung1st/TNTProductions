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
		[JsonProperty("receipt_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ReceiptID { get; set; }
		[JsonProperty("item_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemID { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Quantity { get; set; }
		[JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Price { get; set; }
		[JsonProperty("date_expired", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DateExpired { get; set; }
		[JsonProperty("exported_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime ExportedDate { get; set; }
		[JsonProperty("is_unit1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsUnit1 { get; set; }
		[JsonProperty("inventory_receipt", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public InventoryReceiptViewModel InventoryReceiptVM { get; set; }
		[JsonProperty("product_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
