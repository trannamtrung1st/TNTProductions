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
	public partial class SystemPartnerMappingDomain : BaseDomain<Models.SystemPartnerMapping, SystemPartnerMappingViewModel, int, ISystemPartnerMappingService>
	{
		public SystemPartnerMappingDomain() : base()
		{
		}
		public SystemPartnerMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
