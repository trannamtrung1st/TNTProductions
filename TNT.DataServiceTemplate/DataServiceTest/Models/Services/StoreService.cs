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
	public partial interface IStoreService : IBaseService<Store, StoreViewModel, int>
	{
	}
	
	public partial class StoreService : BaseService<Store, StoreViewModel, int>, IStoreService
	{
		public StoreService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreService()
		{
			repository = G.TContainer.Resolve<IStoreRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreService()
		{
			Dispose(false);
		}
		#endregion
	}
}
