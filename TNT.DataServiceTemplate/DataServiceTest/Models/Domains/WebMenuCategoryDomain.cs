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
	public partial class WebMenuCategoryDomain : BaseDomain<Models.WebMenuCategory, WebMenuCategoryViewModel, int, IWebMenuCategoryService>
	{
		public WebMenuCategoryDomain() : base()
		{
		}
		public WebMenuCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
