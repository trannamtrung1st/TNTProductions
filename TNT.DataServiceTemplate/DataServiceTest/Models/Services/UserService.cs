using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IUserService : IBaseService<User, UserViewModel, System.Guid>
	{
	}
	
	public partial class UserService : BaseService<User, UserViewModel, System.Guid>, IUserService
	{
		public UserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IUserRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public UserService()
		{
			repository = G.TContainer.Resolve<IUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~UserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
