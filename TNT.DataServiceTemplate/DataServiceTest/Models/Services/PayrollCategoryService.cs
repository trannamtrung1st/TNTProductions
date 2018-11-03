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
	public partial interface IPayrollCategoryService : IBaseService<PayrollCategory, PayrollCategoryViewModel, int>
	{
	}
	
	public partial class PayrollCategoryService : BaseService<PayrollCategory, PayrollCategoryViewModel, int>, IPayrollCategoryService
	{
		public PayrollCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PayrollCategoryService()
		{
			repository = G.TContainer.Resolve<IPayrollCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayrollCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
