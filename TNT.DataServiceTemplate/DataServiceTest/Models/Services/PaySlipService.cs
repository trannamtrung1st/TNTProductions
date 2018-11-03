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
	public partial interface IPaySlipService : IBaseService<PaySlip, PaySlipViewModel, int>
	{
	}
	
	public partial class PaySlipService : BaseService<PaySlip, PaySlipViewModel, int>, IPaySlipService
	{
		public PaySlipService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PaySlipService()
		{
			repository = G.TContainer.Resolve<IPaySlipRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipService()
		{
			Dispose(false);
		}
		#endregion
	}
}
