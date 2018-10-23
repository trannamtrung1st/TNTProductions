using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class InventoryReceiptItemPK
	{
		public int ReceiptID { get; set; }
		public int ItemID { get; set; }
		public DateTime ExportedDate { get; set; }
	}
	
	public partial class InventoryReceiptItem : BaseEntity<InventoryReceiptItemViewModel>
	{
		public override InventoryReceiptItemViewModel ToViewModel()
		{
			return new InventoryReceiptItemViewModel(this);
		}
		
	}
}
