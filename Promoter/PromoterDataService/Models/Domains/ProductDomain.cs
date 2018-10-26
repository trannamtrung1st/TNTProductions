using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
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
