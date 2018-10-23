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
	public partial class ProductCollectionItemMappingDomain : BaseDomain<Models.ProductCollectionItemMapping, ProductCollectionItemMappingViewModel, int, IProductCollectionItemMappingService>
	{
		public ProductCollectionItemMappingDomain() : base()
		{
		}
		public ProductCollectionItemMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
