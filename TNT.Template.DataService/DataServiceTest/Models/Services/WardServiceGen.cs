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
	public partial interface IWardService : IBaseService<Ward, int>
	{
	}
	
	public partial class WardService : BaseService<Ward, int>, IWardService
	{
		public WardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWardRepository>(uow);
		}
		
		public WardService(DbContext context)
		{
			repository = G.TContainer.Resolve<IWardRepository>(context);
		}
		
	}
}
