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
	public partial interface IAspNetRoleService : IBaseService<AspNetRole, string>
	{
	}
	
	public partial class AspNetRoleService : BaseService<AspNetRole, string>, IAspNetRoleService
	{
		public AspNetRoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetRoleRepository>(uow);
		}
		
		public AspNetRoleService(DbContext context)
		{
			repository = G.TContainer.Resolve<IAspNetRoleRepository>(context);
		}
		
	}
}
