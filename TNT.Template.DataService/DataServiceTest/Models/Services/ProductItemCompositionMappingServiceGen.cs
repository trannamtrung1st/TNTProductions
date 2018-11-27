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
	public partial interface IProductItemCompositionMappingService : IBaseService<ProductItemCompositionMapping, ProductItemCompositionMappingPK>
	{
	}
	
	public partial class ProductItemCompositionMappingService : BaseService<ProductItemCompositionMapping, ProductItemCompositionMappingPK>, IProductItemCompositionMappingService
	{
		public ProductItemCompositionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemCompositionMappingRepository>(uow);
		}
		
	}
}
