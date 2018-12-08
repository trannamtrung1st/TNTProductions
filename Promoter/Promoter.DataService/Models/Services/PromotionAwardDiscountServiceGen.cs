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
	public partial interface IPromotionAwardDiscountService : IBaseService<PromotionAwardDiscount, int>
	{
	}
	
	public partial class PromotionAwardDiscountService : BaseService<PromotionAwardDiscount, int>, IPromotionAwardDiscountService
	{
		public PromotionAwardDiscountService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionAwardDiscountRepository>(uow);
		}
		
		public PromotionAwardDiscountService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionAwardDiscountRepository>(context);
		}
		
	}
}
