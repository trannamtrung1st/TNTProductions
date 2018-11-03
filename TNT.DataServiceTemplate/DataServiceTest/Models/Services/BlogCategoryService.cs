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
	public partial interface IBlogCategoryService : IBaseService<BlogCategory, BlogCategoryViewModel, int>
	{
	}
	
	public partial class BlogCategoryService : BaseService<BlogCategory, BlogCategoryViewModel, int>, IBlogCategoryService
	{
		public BlogCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BlogCategoryService()
		{
			repository = G.TContainer.Resolve<IBlogCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
