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
	public partial interface IGiftDetailService : IBaseService<GiftDetail, GiftDetailViewModel, GiftDetailPK>
	{
	}
	
	public partial class GiftDetailService : BaseService<GiftDetail, GiftDetailViewModel, GiftDetailPK>, IGiftDetailService
	{
		public GiftDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGiftDetailRepository>(uow);
		}
		
	}
}
