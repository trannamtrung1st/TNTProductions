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
	public partial interface IPromotionAwardGiftService : IBaseService<PromotionAwardGift, int>
	{
	}
	
	public partial class PromotionAwardGiftService : BaseService<PromotionAwardGift, int>, IPromotionAwardGiftService
	{
		public PromotionAwardGiftService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionAwardGiftRepository>(uow);
		}
		
		public PromotionAwardGiftService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionAwardGiftRepository>(context);
		}
		
	}
}
