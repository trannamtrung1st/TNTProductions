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
	public partial interface IPromotionAwardCashbackService : IBaseService<PromotionAwardCashback, int>
	{
	}
	
	public partial class PromotionAwardCashbackService : BaseService<PromotionAwardCashback, int>, IPromotionAwardCashbackService
	{
		public PromotionAwardCashbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionAwardCashbackRepository>(uow);
		}
		
		public PromotionAwardCashbackService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionAwardCashbackRepository>(context);
		}
		
	}
}
