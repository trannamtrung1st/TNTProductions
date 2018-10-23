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
	public partial class BlogCategoryDomain : BaseDomain<Models.BlogCategory, BlogCategoryViewModel, int, IBlogCategoryService>
	{
		public BlogCategoryDomain() : base()
		{
		}
		public BlogCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
