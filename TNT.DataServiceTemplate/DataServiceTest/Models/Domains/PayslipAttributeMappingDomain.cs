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
	public partial class PayslipAttributeMappingDomain : BaseDomain<Models.PayslipAttributeMapping, PayslipAttributeMappingViewModel, int, IPayslipAttributeMappingService>
	{
		public PayslipAttributeMappingDomain() : base()
		{
		}
		public PayslipAttributeMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
