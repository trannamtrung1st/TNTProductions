using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IBlogPostCollectionItemService : IBaseService<BlogPostCollectionItem, int>
	{
	}
	
	public partial class BlogPostCollectionItemService : BaseService<BlogPostCollectionItem, int>, IBlogPostCollectionItemService
	{
		public BlogPostCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionItemRepository>(uow);
		}
		
	}
}
