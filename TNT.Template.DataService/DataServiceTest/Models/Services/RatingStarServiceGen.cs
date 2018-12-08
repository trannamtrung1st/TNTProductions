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
	public partial interface IRatingStarService : IBaseService<RatingStar, int>
	{
	}
	
	public partial class RatingStarService : BaseService<RatingStar, int>, IRatingStarService
	{
		public RatingStarService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingStarRepository>(uow);
		}
		
		public RatingStarService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRatingStarRepository>(context);
		}
		
	}
}
