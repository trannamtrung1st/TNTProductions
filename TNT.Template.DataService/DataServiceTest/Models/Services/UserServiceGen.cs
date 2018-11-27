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
	public partial interface IUserService : IBaseService<User, System.Guid>
	{
	}
	
	public partial class UserService : BaseService<User, System.Guid>, IUserService
	{
		public UserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IUserRepository>(uow);
		}
		
	}
}
