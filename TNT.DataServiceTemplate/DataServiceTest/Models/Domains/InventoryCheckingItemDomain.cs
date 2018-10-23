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
	public partial class InventoryCheckingItemDomain : BaseDomain<Models.InventoryCheckingItem, InventoryCheckingItemViewModel, int, IInventoryCheckingItemService>
	{
		public InventoryCheckingItemDomain() : base()
		{
		}
		public InventoryCheckingItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
