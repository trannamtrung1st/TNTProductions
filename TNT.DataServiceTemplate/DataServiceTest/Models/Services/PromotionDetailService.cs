using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IPromotionDetailService : IBaseService<PromotionDetail, PromotionDetailViewModel, int>
	{
	}
	
	public partial class PromotionDetailService : BaseService<PromotionDetail, PromotionDetailViewModel, int>, IPromotionDetailService
	{
		public PromotionDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionDetailRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PromotionDetailService()
		{
			repository = G.TContainer.Resolve<IPromotionDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
