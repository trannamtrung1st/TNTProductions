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
	public partial interface IProductSpecificationService : IBaseService<ProductSpecification, int>
	{
	}
	
	public partial class ProductSpecificationService : BaseService<ProductSpecification, int>, IProductSpecificationService
	{
		public ProductSpecificationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductSpecificationRepository>(uow);
		}
		
		public ProductSpecificationService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductSpecificationRepository>(context);
		}
		
	}
}
