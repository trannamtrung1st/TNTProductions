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
	public partial class ProductCollectionDomain : BaseDomain<Models.ProductCollection, ProductCollectionViewModel, int, IProductCollectionService>
	{
		public ProductCollectionDomain() : base()
		{
		}
		public ProductCollectionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
