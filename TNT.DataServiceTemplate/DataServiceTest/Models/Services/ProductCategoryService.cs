using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IProductCategoryService : IBaseService<ProductCategory, ProductCategoryViewModel, int>
	{
	}
	
	public partial class ProductCategoryService : BaseService<ProductCategory, ProductCategoryViewModel, int>, IProductCategoryService
	{
		public ProductCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductCategoryService()
		{
			repository = G.TContainer.Resolve<IProductCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
