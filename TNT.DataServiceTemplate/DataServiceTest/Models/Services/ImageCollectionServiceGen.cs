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

namespace DataServiceTest.Models.Services
{
	public partial interface IImageCollectionService : IBaseService<ImageCollection, int>
	{
	}
	
	public partial class ImageCollectionService : BaseService<ImageCollection, int>, IImageCollectionService
	{
		public ImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IImageCollectionRepository>(uow);
		}
		
	}
}
