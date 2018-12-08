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
	public partial interface IAreaDeliveryService : IBaseService<AreaDelivery, int>
	{
	}
	
	public partial class AreaDeliveryService : BaseService<AreaDelivery, int>, IAreaDeliveryService
	{
		public AreaDeliveryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAreaDeliveryRepository>(uow);
		}
		
		public AreaDeliveryService(DbContext context)
		{
			repository = G.TContainer.Resolve<IAreaDeliveryRepository>(context);
		}
		
	}
}
