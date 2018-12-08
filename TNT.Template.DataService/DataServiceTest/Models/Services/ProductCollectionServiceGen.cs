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
	public partial interface IProductCollectionService : IBaseService<ProductCollection, int>
	{
	}
	
	public partial class ProductCollectionService : BaseService<ProductCollection, int>, IProductCollectionService
	{
		public ProductCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionRepository>(uow);
		}
		
		public ProductCollectionService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductCollectionRepository>(context);
		}
		
	}
}
