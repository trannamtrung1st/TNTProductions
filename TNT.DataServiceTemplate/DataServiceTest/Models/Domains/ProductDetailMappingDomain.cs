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
	public partial class ProductDetailMappingDomain : BaseDomain<Models.ProductDetailMapping, ProductDetailMappingViewModel, int, IProductDetailMappingService>
	{
		public ProductDetailMappingDomain() : base()
		{
		}
		public ProductDetailMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
