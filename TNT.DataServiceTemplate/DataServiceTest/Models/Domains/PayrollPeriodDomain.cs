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
	public partial class PayrollPeriodDomain : BaseDomain<Models.PayrollPeriod, PayrollPeriodViewModel, int, IPayrollPeriodService>
	{
		public PayrollPeriodDomain() : base()
		{
		}
		public PayrollPeriodDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
