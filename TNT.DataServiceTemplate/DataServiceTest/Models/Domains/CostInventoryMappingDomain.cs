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
	public partial class CostInventoryMappingDomain : BaseDomain<Models.CostInventoryMapping, CostInventoryMappingViewModel, CostInventoryMappingPK, ICostInventoryMappingService>
	{
		public CostInventoryMappingDomain() : base()
		{
		}
		public CostInventoryMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
