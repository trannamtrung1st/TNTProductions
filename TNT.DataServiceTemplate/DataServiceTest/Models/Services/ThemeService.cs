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
	public partial interface IThemeService : IBaseService<Theme, ThemeViewModel, int>
	{
	}
	
	public partial class ThemeService : BaseService<Theme, ThemeViewModel, int>, IThemeService
	{
		public ThemeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IThemeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ThemeService()
		{
			repository = G.TContainer.Resolve<IThemeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ThemeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
