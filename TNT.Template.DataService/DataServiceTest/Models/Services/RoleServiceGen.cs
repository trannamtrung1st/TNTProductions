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
	public partial interface IRoleService : IBaseService<Role, System.Guid>
	{
	}
	
	public partial class RoleService : BaseService<Role, System.Guid>, IRoleService
	{
		public RoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRoleRepository>(uow);
		}
		
		public RoleService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRoleRepository>(context);
		}
		
	}
}
