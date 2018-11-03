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
	public partial interface IProductService : IBaseService<Product, ProductViewModel, int>
	{
	}
	
	public partial class ProductService : BaseService<Product, ProductViewModel, int>, IProductService
	{
		public ProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductService()
		{
			repository = G.TContainer.Resolve<IProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
