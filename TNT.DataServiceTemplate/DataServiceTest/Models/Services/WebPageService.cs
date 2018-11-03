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
	public partial interface IWebPageService : IBaseService<WebPage, WebPageViewModel, int>
	{
	}
	
	public partial class WebPageService : BaseService<WebPage, WebPageViewModel, int>, IWebPageService
	{
		public WebPageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebPageRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebPageService()
		{
			repository = G.TContainer.Resolve<IWebPageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebPageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
