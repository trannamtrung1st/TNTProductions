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
	public partial interface IProductImageService : IBaseService<ProductImage, ProductImageViewModel, int>
	{
	}
	
	public partial class ProductImageService : BaseService<ProductImage, ProductImageViewModel, int>, IProductImageService
	{
		public ProductImageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductImageService()
		{
			repository = G.TContainer.Resolve<IProductImageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
