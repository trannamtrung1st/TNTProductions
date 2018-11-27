using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IProductImageCollectionItemMappingService : IBaseService<ProductImageCollectionItemMapping, int>
	{
	}
	
	public partial class ProductImageCollectionItemMappingService : BaseService<ProductImageCollectionItemMapping, int>, IProductImageCollectionItemMappingService
	{
		public ProductImageCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionItemMappingRepository>(uow);
		}
		
	}
}
