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
	public partial interface IProductDetailMappingService : IBaseService<ProductDetailMapping, int>
	{
	}
	
	public partial class ProductDetailMappingService : BaseService<ProductDetailMapping, int>, IProductDetailMappingService
	{
		public ProductDetailMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductDetailMappingRepository>(uow);
		}
		
		public ProductDetailMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductDetailMappingRepository>(context);
		}
		
	}
}
