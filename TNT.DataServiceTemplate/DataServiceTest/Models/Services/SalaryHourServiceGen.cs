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
	public partial interface ISalaryHourService : IBaseService<SalaryHour, int>
	{
	}
	
	public partial class SalaryHourService : BaseService<SalaryHour, int>, ISalaryHourService
	{
		public SalaryHourService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISalaryHourRepository>(uow);
		}
		
	}
}
