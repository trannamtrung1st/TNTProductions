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
	public partial class ProductItemDomain : BaseDomain<Models.ProductItem, ProductItemViewModel, int, IProductItemService>
	{
		public ProductItemDomain() : base()
		{
		}
		public ProductItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
