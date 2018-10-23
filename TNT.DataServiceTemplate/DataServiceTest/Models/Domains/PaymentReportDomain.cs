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
	public partial class PaymentReportDomain : BaseDomain<Models.PaymentReport, PaymentReportViewModel, int, IPaymentReportService>
	{
		public PaymentReportDomain() : base()
		{
		}
		public PaymentReportDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
