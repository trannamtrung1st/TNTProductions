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
	public partial interface IImageCollectionItemService : IBaseService<ImageCollectionItem, ImageCollectionItemViewModel, int>
	{
	}
	
	public partial class ImageCollectionItemService : BaseService<ImageCollectionItem, ImageCollectionItemViewModel, int>, IImageCollectionItemService
	{
		public ImageCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ImageCollectionItemService()
		{
			repository = G.TContainer.Resolve<IImageCollectionItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ImageCollectionItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
