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
	public partial interface IStoreThemeService : IBaseService<StoreTheme, StoreThemeViewModel, int>
	{
	}
	
	public partial class StoreThemeService : BaseService<StoreTheme, StoreThemeViewModel, int>, IStoreThemeService
	{
		public StoreThemeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreThemeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreThemeService()
		{
			repository = G.TContainer.Resolve<IStoreThemeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreThemeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
