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
	public partial interface IProductImageCollectionService : IBaseService<ProductImageCollection, ProductImageCollectionViewModel, int>
	{
	}
	
	public partial class ProductImageCollectionService : BaseService<ProductImageCollection, ProductImageCollectionViewModel, int>, IProductImageCollectionService
	{
		public ProductImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductImageCollectionService()
		{
			repository = G.TContainer.Resolve<IProductImageCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
