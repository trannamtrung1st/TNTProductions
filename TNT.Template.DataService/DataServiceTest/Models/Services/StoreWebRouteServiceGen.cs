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
	public partial interface IStoreWebRouteService : IBaseService<StoreWebRoute, int>
	{
	}
	
	public partial class StoreWebRouteService : BaseService<StoreWebRoute, int>, IStoreWebRouteService
	{
		public StoreWebRouteService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebRouteRepository>(uow);
		}
		
		public StoreWebRouteService(DbContext context)
		{
			repository = G.TContainer.Resolve<IStoreWebRouteRepository>(context);
		}
		
	}
}
