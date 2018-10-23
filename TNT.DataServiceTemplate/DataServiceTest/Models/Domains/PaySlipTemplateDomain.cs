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
	public partial class PaySlipTemplateDomain : BaseDomain<Models.PaySlipTemplate, PaySlipTemplateViewModel, int, IPaySlipTemplateService>
	{
		public PaySlipTemplateDomain() : base()
		{
		}
		public PaySlipTemplateDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
