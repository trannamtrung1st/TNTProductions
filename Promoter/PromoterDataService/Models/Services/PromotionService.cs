using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IPromotionService : IBaseService<Promotion, PromotionViewModel, int>
	{
	}
	
	public partial class PromotionService : BaseService<Promotion, PromotionViewModel, int>, IPromotionService
	{
		public PromotionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionRepository>(uow);
		}
		
	}
}
