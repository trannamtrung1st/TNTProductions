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
	public partial class ProductImageCollectionItemMappingDomain : BaseDomain<Models.ProductImageCollectionItemMapping, ProductImageCollectionItemMappingViewModel, int, IProductImageCollectionItemMappingService>
	{
		public ProductImageCollectionItemMappingDomain() : base()
		{
		}
		public ProductImageCollectionItemMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
