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

namespace DataServiceTest.Models.Services
{
	public partial interface IStoreGroupService : IBaseService<StoreGroup, int>
	{
	}
	
	public partial class StoreGroupService : BaseService<StoreGroup, int>, IStoreGroupService
	{
		public StoreGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreGroupRepository>(uow);
		}
		
	}
}
