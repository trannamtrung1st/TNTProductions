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
	public partial class PaymentDomain : BaseDomain<Models.Payment, PaymentViewModel, int, IPaymentService>
	{
		public PaymentDomain() : base()
		{
		}
		public PaymentDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
