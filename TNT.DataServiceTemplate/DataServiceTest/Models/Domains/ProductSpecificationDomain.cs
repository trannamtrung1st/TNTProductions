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
	public partial class ProductSpecificationDomain : BaseDomain<Models.ProductSpecification, ProductSpecificationViewModel, int, IProductSpecificationService>
	{
		public ProductSpecificationDomain() : base()
		{
		}
		public ProductSpecificationDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
