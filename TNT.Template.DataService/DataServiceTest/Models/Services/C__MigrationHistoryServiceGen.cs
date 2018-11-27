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
	public partial interface IC__MigrationHistoryService : IBaseService<C__MigrationHistory, C__MigrationHistoryPK>
	{
	}
	
	public partial class C__MigrationHistoryService : BaseService<C__MigrationHistory, C__MigrationHistoryPK>, IC__MigrationHistoryService
	{
		public C__MigrationHistoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IC__MigrationHistoryRepository>(uow);
		}
		
	}
}
