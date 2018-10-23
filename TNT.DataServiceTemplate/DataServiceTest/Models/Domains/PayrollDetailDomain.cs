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
	public partial class PayrollDetailDomain : BaseDomain<Models.PayrollDetail, PayrollDetailViewModel, int, IPayrollDetailService>
	{
		public PayrollDetailDomain() : base()
		{
		}
		public PayrollDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
