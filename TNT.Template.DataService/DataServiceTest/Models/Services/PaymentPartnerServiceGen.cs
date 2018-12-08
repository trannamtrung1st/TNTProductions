using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IPaymentPartnerService : IBaseService<PaymentPartner, int>
	{
	}
	
	public partial class PaymentPartnerService : BaseService<PaymentPartner, int>, IPaymentPartnerService
	{
		public PaymentPartnerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentPartnerRepository>(uow);
		}
		
		public PaymentPartnerService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPaymentPartnerRepository>(context);
		}
		
	}
}
