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
	public partial interface IAffliatorCashbackDetailService : IBaseService<AffliatorCashbackDetail, AffliatorCashbackDetailViewModel, int>
	{
	}
	
	public partial class AffliatorCashbackDetailService : BaseService<AffliatorCashbackDetail, AffliatorCashbackDetailViewModel, int>, IAffliatorCashbackDetailService
	{
		public AffliatorCashbackDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAffliatorCashbackDetailRepository>(uow);
		}
		
	}
}
