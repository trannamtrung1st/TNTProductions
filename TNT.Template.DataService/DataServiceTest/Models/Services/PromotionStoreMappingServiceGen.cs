using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IPromotionStoreMappingService : IBaseService<PromotionStoreMapping, int>
	{
	}
	
	public partial class PromotionStoreMappingService : BaseService<PromotionStoreMapping, int>, IPromotionStoreMappingService
	{
		public PromotionStoreMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionStoreMappingRepository>(uow);
		}
		
		public PromotionStoreMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPromotionStoreMappingRepository>(context);
		}
		
	}
}
