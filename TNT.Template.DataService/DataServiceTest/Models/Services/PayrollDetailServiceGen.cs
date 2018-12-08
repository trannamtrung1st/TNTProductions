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
	public partial interface IPayrollDetailService : IBaseService<PayrollDetail, int>
	{
	}
	
	public partial class PayrollDetailService : BaseService<PayrollDetail, int>, IPayrollDetailService
	{
		public PayrollDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollDetailRepository>(uow);
		}
		
		public PayrollDetailService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPayrollDetailRepository>(context);
		}
		
	}
}
