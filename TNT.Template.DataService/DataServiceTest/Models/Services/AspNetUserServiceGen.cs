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
	public partial interface IAspNetUserService : IBaseService<AspNetUser, string>
	{
	}
	
	public partial class AspNetUserService : BaseService<AspNetUser, string>, IAspNetUserService
	{
		public AspNetUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserRepository>(uow);
		}
		
		public AspNetUserService(DbContext context)
		{
			repository = G.TContainer.Resolve<IAspNetUserRepository>(context);
		}
		
	}
}
