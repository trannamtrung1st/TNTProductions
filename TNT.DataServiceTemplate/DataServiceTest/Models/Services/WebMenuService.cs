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
	public partial interface IWebMenuService : IBaseService<WebMenu, WebMenuViewModel, int>
	{
	}
	
	public partial class WebMenuService : BaseService<WebMenu, WebMenuViewModel, int>, IWebMenuService
	{
		public WebMenuService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebMenuRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebMenuService()
		{
			repository = G.TContainer.Resolve<IWebMenuRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebMenuService()
		{
			Dispose(false);
		}
		#endregion
	}
}
