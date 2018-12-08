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
	public partial interface IDayModeService : IBaseService<DayMode, int>
	{
	}
	
	public partial class DayModeService : BaseService<DayMode, int>, IDayModeService
	{
		public DayModeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDayModeRepository>(uow);
		}
		
		public DayModeService(DbContext context)
		{
			repository = G.TContainer.Resolve<IDayModeRepository>(context);
		}
		
	}
}
