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
	public partial interface IPromotionStoreMappingService : IBaseService<PromotionStoreMapping, PromotionStoreMappingViewModel, int>
	{
	}
	
	public partial class PromotionStoreMappingService : BaseService<PromotionStoreMapping, PromotionStoreMappingViewModel, int>, IPromotionStoreMappingService
	{
		public PromotionStoreMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionStoreMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PromotionStoreMappingService()
		{
			repository = G.TContainer.Resolve<IPromotionStoreMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionStoreMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
