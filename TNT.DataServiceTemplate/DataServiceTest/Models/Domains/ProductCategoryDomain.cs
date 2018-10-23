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
	public partial class ProductCategoryDomain : BaseDomain<Models.ProductCategory, ProductCategoryViewModel, int, IProductCategoryService>
	{
		public ProductCategoryDomain() : base()
		{
		}
		public ProductCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
