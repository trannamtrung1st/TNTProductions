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
	public partial interface IBlogPostService : IBaseService<BlogPost, BlogPostViewModel, int>
	{
	}
	
	public partial class BlogPostService : BaseService<BlogPost, BlogPostViewModel, int>, IBlogPostService
	{
		public BlogPostService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BlogPostService()
		{
			repository = G.TContainer.Resolve<IBlogPostRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostService()
		{
			Dispose(false);
		}
		#endregion
	}
}
