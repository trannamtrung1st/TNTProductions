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
	public partial class CustomerStoreReportMappingDomain : BaseDomain<Models.CustomerStoreReportMapping, CustomerStoreReportMappingViewModel, int, ICustomerStoreReportMappingService>
	{
		public CustomerStoreReportMappingDomain() : base()
		{
		}
		public CustomerStoreReportMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
