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
	public partial class ProductDomain : BaseDomain<Models.Product, ProductViewModel, int, IProductService>
	{
		public ProductDomain() : base()
		{
		}
		public ProductDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
