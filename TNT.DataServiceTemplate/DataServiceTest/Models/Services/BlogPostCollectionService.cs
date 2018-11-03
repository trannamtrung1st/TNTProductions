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
	public partial interface IBlogPostCollectionService : IBaseService<BlogPostCollection, BlogPostCollectionViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionService : BaseService<BlogPostCollection, BlogPostCollectionViewModel, int>, IBlogPostCollectionService
	{
		public BlogPostCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BlogPostCollectionService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
