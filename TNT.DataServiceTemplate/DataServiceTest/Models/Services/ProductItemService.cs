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
	public partial interface IProductItemService : IBaseService<ProductItem, ProductItemViewModel, int>
	{
	}
	
	public partial class ProductItemService : BaseService<ProductItem, ProductItemViewModel, int>, IProductItemService
	{
		public ProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductItemService()
		{
			repository = G.TContainer.Resolve<IProductItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
