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
	public partial interface IStoreUserService : IBaseService<StoreUser, StoreUserPK>
	{
	}
	
	public partial class StoreUserService : BaseService<StoreUser, StoreUserPK>, IStoreUserService
	{
		public StoreUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreUserRepository>(uow);
		}
		
		public StoreUserService(DbContext context)
		{
			repository = G.TContainer.Resolve<IStoreUserRepository>(context);
		}
		
	}
}
