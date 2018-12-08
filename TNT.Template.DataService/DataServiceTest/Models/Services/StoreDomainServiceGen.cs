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
	public partial interface IStoreDomainService : IBaseService<StoreDomain, int>
	{
	}
	
	public partial class StoreDomainService : BaseService<StoreDomain, int>, IStoreDomainService
	{
		public StoreDomainService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreDomainRepository>(uow);
		}
		
		public StoreDomainService(DbContext context)
		{
			repository = G.TContainer.Resolve<IStoreDomainRepository>(context);
		}
		
	}
}
