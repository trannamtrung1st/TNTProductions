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
	public partial class BlogPostCollectionDomain : BaseDomain<Models.BlogPostCollection, BlogPostCollectionViewModel, int, IBlogPostCollectionService>
	{
		public BlogPostCollectionDomain() : base()
		{
		}
		public BlogPostCollectionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
