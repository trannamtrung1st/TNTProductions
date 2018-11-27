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
	public partial interface ICouponProviderService : IBaseService<CouponProvider, int>
	{
	}
	
	public partial class CouponProviderService : BaseService<CouponProvider, int>, ICouponProviderService
	{
		public CouponProviderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponProviderRepository>(uow);
		}
		
	}
}
