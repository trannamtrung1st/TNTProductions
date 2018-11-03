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
	public partial interface IWebElementTypeService : IBaseService<WebElementType, WebElementTypeViewModel, int>
	{
	}
	
	public partial class WebElementTypeService : BaseService<WebElementType, WebElementTypeViewModel, int>, IWebElementTypeService
	{
		public WebElementTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebElementTypeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebElementTypeService()
		{
			repository = G.TContainer.Resolve<IWebElementTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebElementTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
