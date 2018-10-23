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
	public partial class BlogPostDomain : BaseDomain<Models.BlogPost, BlogPostViewModel, int, IBlogPostService>
	{
		public BlogPostDomain() : base()
		{
		}
		public BlogPostDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
