using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IImageCollectionItemService : IBaseService<ImageCollectionItem, int>
	{
	}
	
	public partial class ImageCollectionItemService : BaseService<ImageCollectionItem, int>, IImageCollectionItemService
	{
		public ImageCollectionItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionItemRepository>(uow);
		}
		
		public ImageCollectionItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IImageCollectionItemRepository>(context);
		}
		
	}
}
