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
	public partial interface ICheckFingerService : IBaseService<CheckFinger, int>
	{
	}
	
	public partial class CheckFingerService : BaseService<CheckFinger, int>, ICheckFingerService
	{
		public CheckFingerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICheckFingerRepository>(uow);
		}
		
		public CheckFingerService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICheckFingerRepository>(context);
		}
		
	}
}
