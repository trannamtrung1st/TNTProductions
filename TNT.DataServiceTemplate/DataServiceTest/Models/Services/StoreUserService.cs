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
	public partial interface IStoreUserService : IBaseService<StoreUser, StoreUserViewModel, StoreUserPK>
	{
	}
	
	public partial class StoreUserService : BaseService<StoreUser, StoreUserViewModel, StoreUserPK>, IStoreUserService
	{
		public StoreUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreUserRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreUserService()
		{
			repository = G.TContainer.Resolve<IStoreUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
