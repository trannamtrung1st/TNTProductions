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
	public partial interface IOrderPromotionMappingService : IBaseService<OrderPromotionMapping, int>
	{
	}
	
	public partial class OrderPromotionMappingService : BaseService<OrderPromotionMapping, int>, IOrderPromotionMappingService
	{
		public OrderPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderPromotionMappingRepository>(uow);
		}
		
		public OrderPromotionMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IOrderPromotionMappingRepository>(context);
		}
		
	}
}
