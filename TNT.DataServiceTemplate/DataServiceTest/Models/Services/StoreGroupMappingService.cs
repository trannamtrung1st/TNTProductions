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
	public partial interface IStoreGroupMappingService : IBaseService<StoreGroupMapping, StoreGroupMappingViewModel, int>
	{
	}
	
	public partial class StoreGroupMappingService : BaseService<StoreGroupMapping, StoreGroupMappingViewModel, int>, IStoreGroupMappingService
	{
		public StoreGroupMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreGroupMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreGroupMappingService()
		{
			repository = G.TContainer.Resolve<IStoreGroupMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreGroupMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
