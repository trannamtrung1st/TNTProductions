using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IProductService : IBaseService<Product, int>
	{
	}
	
	public partial class ProductService : BaseService<Product, int>, IProductService
	{
		public ProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductRepository>(uow);
		}
		
	}
}
