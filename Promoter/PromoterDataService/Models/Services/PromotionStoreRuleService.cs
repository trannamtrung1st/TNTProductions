using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IPromotionStoreRuleService : IBaseService<PromotionStoreRule, PromotionStoreRulePK>
	{
	}
	
	public partial class PromotionStoreRuleService : BaseService<PromotionStoreRule, PromotionStoreRulePK>, IPromotionStoreRuleService
	{
		public PromotionStoreRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionStoreRuleRepository>(uow);
		}
		
	}
}
