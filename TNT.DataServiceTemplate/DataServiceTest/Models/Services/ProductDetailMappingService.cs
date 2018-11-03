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
	public partial interface IProductDetailMappingService : IBaseService<ProductDetailMapping, ProductDetailMappingViewModel, int>
	{
	}
	
	public partial class ProductDetailMappingService : BaseService<ProductDetailMapping, ProductDetailMappingViewModel, int>, IProductDetailMappingService
	{
		public ProductDetailMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductDetailMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductDetailMappingService()
		{
			repository = G.TContainer.Resolve<IProductDetailMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductDetailMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
