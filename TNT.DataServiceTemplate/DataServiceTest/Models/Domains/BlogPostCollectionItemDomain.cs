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
	public partial class BlogPostCollectionItemDomain : BaseDomain<Models.BlogPostCollectionItem, BlogPostCollectionItemViewModel, int, IBlogPostCollectionItemService>
	{
		public BlogPostCollectionItemDomain() : base()
		{
		}
		public BlogPostCollectionItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
