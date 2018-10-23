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
	public partial class InventoryCheckingDomain : BaseDomain<Models.InventoryChecking, InventoryCheckingViewModel, int, IInventoryCheckingService>
	{
		public InventoryCheckingDomain() : base()
		{
		}
		public InventoryCheckingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
