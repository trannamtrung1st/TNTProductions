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
	public partial class ProductItemCategoryDomain : BaseDomain<Models.ProductItemCategory, ProductItemCategoryViewModel, int, IProductItemCategoryService>
	{
		public ProductItemCategoryDomain() : base()
		{
		}
		public ProductItemCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
