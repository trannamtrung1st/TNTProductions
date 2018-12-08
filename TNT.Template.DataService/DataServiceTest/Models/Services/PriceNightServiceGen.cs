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
	public partial interface IPriceNightService : IBaseService<PriceNight, int>
	{
	}
	
	public partial class PriceNightService : BaseService<PriceNight, int>, IPriceNightService
	{
		public PriceNightService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceNightRepository>(uow);
		}
		
		public PriceNightService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPriceNightRepository>(context);
		}
		
	}
}
