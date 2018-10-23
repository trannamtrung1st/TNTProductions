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
	public partial class InventoryDateReportDomain : BaseDomain<Models.InventoryDateReport, InventoryDateReportViewModel, int, IInventoryDateReportService>
	{
		public InventoryDateReportDomain() : base()
		{
		}
		public InventoryDateReportDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
