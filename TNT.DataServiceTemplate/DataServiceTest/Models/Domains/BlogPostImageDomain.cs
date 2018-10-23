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
	public partial class BlogPostImageDomain : BaseDomain<Models.BlogPostImage, BlogPostImageViewModel, int, IBlogPostImageService>
	{
		public BlogPostImageDomain() : base()
		{
		}
		public BlogPostImageDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
