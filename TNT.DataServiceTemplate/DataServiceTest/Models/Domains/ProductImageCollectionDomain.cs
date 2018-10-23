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
	public partial class ProductImageCollectionDomain : BaseDomain<Models.ProductImageCollection, ProductImageCollectionViewModel, int, IProductImageCollectionService>
	{
		public ProductImageCollectionDomain() : base()
		{
		}
		public ProductImageCollectionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
