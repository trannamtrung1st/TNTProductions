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
	public partial interface IImageCollectionService : IBaseService<ImageCollection, ImageCollectionViewModel, int>
	{
	}
	
	public partial class ImageCollectionService : BaseService<ImageCollection, ImageCollectionViewModel, int>, IImageCollectionService
	{
		public ImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ImageCollectionService()
		{
			repository = G.TContainer.Resolve<IImageCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ImageCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
