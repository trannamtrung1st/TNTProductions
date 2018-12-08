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
	public partial interface IArticleService : IBaseService<Article, int>
	{
	}
	
	public partial class ArticleService : BaseService<Article, int>, IArticleService
	{
		public ArticleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IArticleRepository>(uow);
		}
		
		public ArticleService(DbContext context)
		{
			repository = G.TContainer.Resolve<IArticleRepository>(context);
		}
		
	}
}
