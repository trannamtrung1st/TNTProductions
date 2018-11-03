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
	public partial interface IWebMenuCategoryService : IBaseService<WebMenuCategory, WebMenuCategoryViewModel, int>
	{
	}
	
	public partial class WebMenuCategoryService : BaseService<WebMenuCategory, WebMenuCategoryViewModel, int>, IWebMenuCategoryService
	{
		public WebMenuCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebMenuCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebMenuCategoryService()
		{
			repository = G.TContainer.Resolve<IWebMenuCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebMenuCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
