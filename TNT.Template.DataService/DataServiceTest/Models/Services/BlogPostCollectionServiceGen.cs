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
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IBlogPostCollectionService : IBaseService<BlogPostCollection, int>
	{
	}
	
	public partial class BlogPostCollectionService : BaseService<BlogPostCollection, int>, IBlogPostCollectionService
	{
		public BlogPostCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBlogPostCollectionRepository>(uow);
		}
		
		public BlogPostCollectionService(DbContext context)
		{
			repository = G.TContainer.Resolve<IBlogPostCollectionRepository>(context);
		}
		
	}
}
