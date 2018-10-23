using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class InventoryReceiptItemDomain : BaseDomain<Models.InventoryReceiptItem, InventoryReceiptItemViewModel, InventoryReceiptItemPK, IInventoryReceiptItemService>
	{
		public InventoryReceiptItemDomain() : base()
		{
		}
		public InventoryReceiptItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
