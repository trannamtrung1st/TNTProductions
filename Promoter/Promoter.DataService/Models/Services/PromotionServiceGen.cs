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
	public partial interface IPromotionService : IBaseService<Promotion, int>
	{
	}
	
	public partial class PromotionService : BaseService<Promotion, int>, IPromotionService
	{
		public PromotionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionRepository>(uow);
		}
		
		public PromotionService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionRepository>(context);
		}
		
	}
}
