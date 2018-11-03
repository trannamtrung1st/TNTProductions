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
	public partial interface IProductItemCompositionMappingService : IBaseService<ProductItemCompositionMapping, ProductItemCompositionMappingViewModel, ProductItemCompositionMappingPK>
	{
	}
	
	public partial class ProductItemCompositionMappingService : BaseService<ProductItemCompositionMapping, ProductItemCompositionMappingViewModel, ProductItemCompositionMappingPK>, IProductItemCompositionMappingService
	{
		public ProductItemCompositionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemCompositionMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductItemCompositionMappingService()
		{
			repository = G.TContainer.Resolve<IProductItemCompositionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductItemCompositionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
