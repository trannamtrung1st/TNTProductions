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
	public partial interface IArticleService : IBaseService<Article, ArticleViewModel, int>
	{
	}
	
	public partial class ArticleService : BaseService<Article, ArticleViewModel, int>, IArticleService
	{
		public ArticleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IArticleRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ArticleService()
		{
			repository = G.TContainer.Resolve<IArticleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ArticleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
