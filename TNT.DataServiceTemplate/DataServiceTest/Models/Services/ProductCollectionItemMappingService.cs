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
	public partial interface IProductCollectionItemMappingService : IBaseService<ProductCollectionItemMapping, ProductCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class ProductCollectionItemMappingService : BaseService<ProductCollectionItemMapping, ProductCollectionItemMappingViewModel, int>, IProductCollectionItemMappingService
	{
		public ProductCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionItemMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IProductCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
