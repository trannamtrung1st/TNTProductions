using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;

namespace Promoter.DataService.Models.Services
{
	public partial interface IBrandAccountService : IBaseService<BrandAccount, int>
	{
	}
	
	public partial class BrandAccountService : BaseService<BrandAccount, int>, IBrandAccountService
	{
		public BrandAccountService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBrandAccountRepository>(uow);
		}
		
		public BrandAccountService(PromoterEntities context)
		{
			repository = G.TContainer.Resolve<IBrandAccountRepository>(context);
		}
		
	}
}
