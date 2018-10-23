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
	public partial class InventoryReceiptDomain : BaseDomain<Models.InventoryReceipt, InventoryReceiptViewModel, int, IInventoryReceiptService>
	{
		public InventoryReceiptDomain() : base()
		{
		}
		public InventoryReceiptDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
