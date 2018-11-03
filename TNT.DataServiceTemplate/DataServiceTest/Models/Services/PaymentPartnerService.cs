using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IPaymentPartnerService : IBaseService<PaymentPartner, PaymentPartnerViewModel, int>
	{
	}
	
	public partial class PaymentPartnerService : BaseService<PaymentPartner, PaymentPartnerViewModel, int>, IPaymentPartnerService
	{
		public PaymentPartnerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentPartnerRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PaymentPartnerService()
		{
			repository = G.TContainer.Resolve<IPaymentPartnerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaymentPartnerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
