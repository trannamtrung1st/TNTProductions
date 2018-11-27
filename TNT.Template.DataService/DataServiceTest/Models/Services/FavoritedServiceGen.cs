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
	public partial interface IFavoritedService : IBaseService<Favorited, int>
	{
	}
	
	public partial class FavoritedService : BaseService<Favorited, int>, IFavoritedService
	{
		public FavoritedService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IFavoritedRepository>(uow);
		}
		
	}
}
