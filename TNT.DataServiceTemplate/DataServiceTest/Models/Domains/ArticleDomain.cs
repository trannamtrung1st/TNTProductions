using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class ArticleDomain : BaseDomain<Models.Article, ArticleViewModel, int, IArticleService>
	{
		public ArticleDomain() : base()
		{
		}
		public ArticleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
