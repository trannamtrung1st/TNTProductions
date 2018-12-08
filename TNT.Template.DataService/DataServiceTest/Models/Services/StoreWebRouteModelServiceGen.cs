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
	public partial interface IStoreWebRouteModelService : IBaseService<StoreWebRouteModel, int>
	{
	}
	
	public partial class StoreWebRouteModelService : BaseService<StoreWebRouteModel, int>, IStoreWebRouteModelService
	{
		public StoreWebRouteModelService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebRouteModelRepository>(uow);
		}
		
		public StoreWebRouteModelService(DbContext context)
		{
			repository = G.TContainer.Resolve<IStoreWebRouteModelRepository>(context);
		}
		
	}
}
