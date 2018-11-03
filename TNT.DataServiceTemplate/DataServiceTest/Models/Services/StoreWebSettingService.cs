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
	public partial interface IStoreWebSettingService : IBaseService<StoreWebSetting, StoreWebSettingViewModel, int>
	{
	}
	
	public partial class StoreWebSettingService : BaseService<StoreWebSetting, StoreWebSettingViewModel, int>, IStoreWebSettingService
	{
		public StoreWebSettingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebSettingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreWebSettingService()
		{
			repository = G.TContainer.Resolve<IStoreWebSettingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreWebSettingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
