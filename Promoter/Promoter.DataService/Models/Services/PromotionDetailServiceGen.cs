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
	public partial interface IPromotionDetailService : IBaseService<PromotionDetail, int>
	{
	}
	
	public partial class PromotionDetailService : BaseService<PromotionDetail, int>, IPromotionDetailService
	{
		public PromotionDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionDetailRepository>(uow);
		}
		
		public PromotionDetailService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionDetailRepository>(context);
		}
		
	}
}
