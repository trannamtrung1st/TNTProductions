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
	public partial class InventoryTemplateReportDomain : BaseDomain<Models.InventoryTemplateReport, InventoryTemplateReportViewModel, int, IInventoryTemplateReportService>
	{
		public InventoryTemplateReportDomain() : base()
		{
		}
		public InventoryTemplateReportDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
