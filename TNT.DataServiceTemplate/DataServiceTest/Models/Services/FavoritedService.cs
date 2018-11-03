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
	public partial interface IFavoritedService : IBaseService<Favorited, FavoritedViewModel, int>
	{
	}
	
	public partial class FavoritedService : BaseService<Favorited, FavoritedViewModel, int>, IFavoritedService
	{
		public FavoritedService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IFavoritedRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public FavoritedService()
		{
			repository = G.TContainer.Resolve<IFavoritedRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~FavoritedService()
		{
			Dispose(false);
		}
		#endregion
	}
}
