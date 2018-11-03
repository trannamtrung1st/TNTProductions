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
	public partial interface IBlogPostCollectionItemMappingService : IBaseService<BlogPostCollectionItemMapping, BlogPostCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class BlogPostCollectionItemMappingService : BaseService<BlogPostCollectionItemMapping, BlogPostCollectionItemMappingViewModel, int>, IBlogPostCollectionItemMappingService
	{
		public BlogPostCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionItemMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BlogPostCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BlogPostCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
