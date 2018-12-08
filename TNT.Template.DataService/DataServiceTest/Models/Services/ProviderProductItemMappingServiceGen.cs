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
	public partial interface IProviderProductItemMappingService : IBaseService<ProviderProductItemMapping, int>
	{
	}
	
	public partial class ProviderProductItemMappingService : BaseService<ProviderProductItemMapping, int>, IProviderProductItemMappingService
	{
		public ProviderProductItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProviderProductItemMappingRepository>(uow);
		}
		
		public ProviderProductItemMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProviderProductItemMappingRepository>(context);
		}
		
	}
}
