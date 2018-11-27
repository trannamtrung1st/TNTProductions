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

namespace DataServiceTest.Models.Services
{
	public partial interface IStoreWebSettingService : IBaseService<StoreWebSetting, int>
	{
	}
	
	public partial class StoreWebSettingService : BaseService<StoreWebSetting, int>, IStoreWebSettingService
	{
		public StoreWebSettingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebSettingRepository>(uow);
		}
		
	}
}
