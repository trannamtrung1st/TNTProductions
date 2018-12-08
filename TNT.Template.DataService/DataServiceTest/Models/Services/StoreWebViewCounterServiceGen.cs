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
	public partial interface IStoreWebViewCounterService : IBaseService<StoreWebViewCounter, int>
	{
	}
	
	public partial class StoreWebViewCounterService : BaseService<StoreWebViewCounter, int>, IStoreWebViewCounterService
	{
		public StoreWebViewCounterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreWebViewCounterRepository>(uow);
		}
		
		public StoreWebViewCounterService(DbContext context)
		{
			repository = G.TContainer.Resolve<IStoreWebViewCounterRepository>(context);
		}
		
	}
}
