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
	public partial class PayslipAttributeDomain : BaseDomain<Models.PayslipAttribute, PayslipAttributeViewModel, int, IPayslipAttributeService>
	{
		public PayslipAttributeDomain() : base()
		{
		}
		public PayslipAttributeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
