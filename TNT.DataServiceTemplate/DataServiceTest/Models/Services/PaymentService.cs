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
	public partial interface IPaymentService : IBaseService<Payment, PaymentViewModel, int>
	{
	}
	
	public partial class PaymentService : BaseService<Payment, PaymentViewModel, int>, IPaymentService
	{
		public PaymentService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PaymentService()
		{
			repository = G.TContainer.Resolve<IPaymentRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaymentService()
		{
			Dispose(false);
		}
		#endregion
	}
}
