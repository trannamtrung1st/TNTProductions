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
	public partial interface IProductCollectionService : IBaseService<ProductCollection, ProductCollectionViewModel, int>
	{
	}
	
	public partial class ProductCollectionService : BaseService<ProductCollection, ProductCollectionViewModel, int>, IProductCollectionService
	{
		public ProductCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductCollectionService()
		{
			repository = G.TContainer.Resolve<IProductCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
