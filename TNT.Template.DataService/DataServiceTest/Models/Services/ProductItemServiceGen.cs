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
	public partial interface IProductItemService : IBaseService<ProductItem, int>
	{
	}
	
	public partial class ProductItemService : BaseService<ProductItem, int>, IProductItemService
	{
		public ProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemRepository>(uow);
		}
		
		public ProductItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductItemRepository>(context);
		}
		
	}
}
