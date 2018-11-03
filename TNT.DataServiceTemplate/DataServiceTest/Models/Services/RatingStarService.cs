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
	public partial interface IRatingStarService : IBaseService<RatingStar, RatingStarViewModel, int>
	{
	}
	
	public partial class RatingStarService : BaseService<RatingStar, RatingStarViewModel, int>, IRatingStarService
	{
		public RatingStarService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingStarRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RatingStarService()
		{
			repository = G.TContainer.Resolve<IRatingStarRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RatingStarService()
		{
			Dispose(false);
		}
		#endregion
	}
}
