using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class InventoryReceipt : BaseEntity<InventoryReceiptViewModel>
	{
		public override InventoryReceiptViewModel ToViewModel()
		{
			return new InventoryReceiptViewModel(this);
		}
		
	}
}
