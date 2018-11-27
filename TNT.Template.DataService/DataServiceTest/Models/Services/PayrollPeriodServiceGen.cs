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

namespace DataServiceTest.Models.Services
{
	public partial interface IPayrollPeriodService : IBaseService<PayrollPeriod, int>
	{
	}
	
	public partial class PayrollPeriodService : BaseService<PayrollPeriod, int>, IPayrollPeriodService
	{
		public PayrollPeriodService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollPeriodRepository>(uow);
		}
		
	}
}
