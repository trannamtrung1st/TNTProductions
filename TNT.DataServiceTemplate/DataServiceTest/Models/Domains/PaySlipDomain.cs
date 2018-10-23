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
	public partial class PaySlipDomain : BaseDomain<Models.PaySlip, PaySlipViewModel, int, IPaySlipService>
	{
		public PaySlipDomain() : base()
		{
		}
		public PaySlipDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
