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
	public partial interface IStoreGroupService : IBaseService<StoreGroup, StoreGroupViewModel, int>
	{
	}
	
	public partial class StoreGroupService : BaseService<StoreGroup, StoreGroupViewModel, int>, IStoreGroupService
	{
		public StoreGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreGroupService()
		{
			repository = G.TContainer.Resolve<IStoreGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
