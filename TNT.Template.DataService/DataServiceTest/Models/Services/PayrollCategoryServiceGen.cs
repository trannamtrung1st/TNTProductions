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
	public partial interface IPayrollCategoryService : IBaseService<PayrollCategory, int>
	{
	}
	
	public partial class PayrollCategoryService : BaseService<PayrollCategory, int>, IPayrollCategoryService
	{
		public PayrollCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollCategoryRepository>(uow);
		}
		
		public PayrollCategoryService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPayrollCategoryRepository>(context);
		}
		
	}
}
