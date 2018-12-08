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
	public partial interface IProviderService : IBaseService<Provider, int>
	{
	}
	
	public partial class ProviderService : BaseService<Provider, int>, IProviderService
	{
		public ProviderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProviderRepository>(uow);
		}
		
		public ProviderService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProviderRepository>(context);
		}
		
	}
}
