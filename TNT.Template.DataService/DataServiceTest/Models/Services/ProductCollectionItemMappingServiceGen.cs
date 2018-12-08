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
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IProductCollectionItemMappingService : IBaseService<ProductCollectionItemMapping, int>
	{
	}
	
	public partial class ProductCollectionItemMappingService : BaseService<ProductCollectionItemMapping, int>, IProductCollectionItemMappingService
	{
		public ProductCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionItemMappingRepository>(uow);
		}
		
		public ProductCollectionItemMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductCollectionItemMappingRepository>(context);
		}
		
	}
}
