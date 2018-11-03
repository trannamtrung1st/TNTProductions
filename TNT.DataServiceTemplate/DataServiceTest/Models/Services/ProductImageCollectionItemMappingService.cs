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
	public partial interface IProductImageCollectionItemMappingService : IBaseService<ProductImageCollectionItemMapping, ProductImageCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class ProductImageCollectionItemMappingService : BaseService<ProductImageCollectionItemMapping, ProductImageCollectionItemMappingViewModel, int>, IProductImageCollectionItemMappingService
	{
		public ProductImageCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionItemMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductImageCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IProductImageCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
