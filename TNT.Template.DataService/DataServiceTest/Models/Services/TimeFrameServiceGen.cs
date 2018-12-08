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
	public partial interface ITimeFrameService : IBaseService<TimeFrame, int>
	{
	}
	
	public partial class TimeFrameService : BaseService<TimeFrame, int>, ITimeFrameService
	{
		public TimeFrameService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITimeFrameRepository>(uow);
		}
		
		public TimeFrameService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITimeFrameRepository>(context);
		}
		
	}
}
