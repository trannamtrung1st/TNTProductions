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
	public partial interface IPayrollDetailService : IBaseService<PayrollDetail, PayrollDetailViewModel, int>
	{
	}
	
	public partial class PayrollDetailService : BaseService<PayrollDetail, PayrollDetailViewModel, int>, IPayrollDetailService
	{
		public PayrollDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollDetailRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PayrollDetailService()
		{
			repository = G.TContainer.Resolve<IPayrollDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayrollDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
