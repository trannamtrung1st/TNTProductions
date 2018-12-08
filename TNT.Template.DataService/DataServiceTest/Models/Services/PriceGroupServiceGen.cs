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
	public partial interface IPriceGroupService : IBaseService<PriceGroup, int>
	{
	}
	
	public partial class PriceGroupService : BaseService<PriceGroup, int>, IPriceGroupService
	{
		public PriceGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceGroupRepository>(uow);
		}
		
		public PriceGroupService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPriceGroupRepository>(context);
		}
		
	}
}
