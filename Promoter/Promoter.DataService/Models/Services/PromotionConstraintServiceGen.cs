using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace Promoter.DataService.Models.Services
{
	public partial interface IPromotionConstraintService : IBaseService<PromotionConstraint, int>
	{
	}
	
	public partial class PromotionConstraintService : BaseService<PromotionConstraint, int>, IPromotionConstraintService
	{
		public PromotionConstraintService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionConstraintRepository>(uow);
		}
		
		public PromotionConstraintService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionConstraintRepository>(context);
		}
		
	}
}
