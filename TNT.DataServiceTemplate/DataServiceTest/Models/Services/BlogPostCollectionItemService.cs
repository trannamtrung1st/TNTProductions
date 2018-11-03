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
	public partial interface IBlogPostCollectionItemService : IBaseService<BlogPostCollectionItem, BlogPostCollectionItemViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionItemService : BaseService<BlogPostCollectionItem, BlogPostCollectionItemViewModel, int>, IBlogPostCollectionItemService
	{
		public BlogPostCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BlogPostCollectionItemService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
