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
	public partial interface IWebElementService : IBaseService<WebElement, WebElementViewModel, int>
	{
	}
	
	public partial class WebElementService : BaseService<WebElement, WebElementViewModel, int>, IWebElementService
	{
		public WebElementService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebElementRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebElementService()
		{
			repository = G.TContainer.Resolve<IWebElementRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebElementService()
		{
			Dispose(false);
		}
		#endregion
	}
}
