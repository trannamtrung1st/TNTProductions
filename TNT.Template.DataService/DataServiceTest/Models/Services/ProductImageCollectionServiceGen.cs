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
	public partial interface IProductImageCollectionService : IBaseService<ProductImageCollection, int>
	{
	}
	
	public partial class ProductImageCollectionService : BaseService<ProductImageCollection, int>, IProductImageCollectionService
	{
		public ProductImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionRepository>(uow);
		}
		
		public ProductImageCollectionService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductImageCollectionRepository>(context);
		}
		
	}
}
