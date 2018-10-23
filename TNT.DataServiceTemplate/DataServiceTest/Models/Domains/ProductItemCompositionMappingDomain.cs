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
	public partial class ProductItemCompositionMappingDomain : BaseDomain<Models.ProductItemCompositionMapping, ProductItemCompositionMappingViewModel, ProductItemCompositionMappingPK, IProductItemCompositionMappingService>
	{
		public ProductItemCompositionMappingDomain() : base()
		{
		}
		public ProductItemCompositionMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
