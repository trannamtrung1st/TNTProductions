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
	public partial interface IProductImageService : IBaseService<ProductImage, int>
	{
	}
	
	public partial class ProductImageService : BaseService<ProductImage, int>, IProductImageService
	{
		public ProductImageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageRepository>(uow);
		}
		
		public ProductImageService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductImageRepository>(context);
		}
		
	}
}
