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
	public partial interface IStoreWebRouteService : IBaseService<StoreWebRoute, StoreWebRouteViewModel, int>
	{
	}
	
	public partial class StoreWebRouteService : BaseService<StoreWebRoute, StoreWebRouteViewModel, int>, IStoreWebRouteService
	{
		public StoreWebRouteService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebRouteRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreWebRouteService()
		{
			repository = G.TContainer.Resolve<IStoreWebRouteRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebRouteService()
		{
			Dispose(false);
		}
		#endregion
	}
}
