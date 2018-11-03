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
	public partial interface IAccountService : IBaseService<Account, AccountViewModel, int>
	{
	}
	
	public partial class AccountService : BaseService<Account, AccountViewModel, int>, IAccountService
	{
		public AccountService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAccountRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AccountService()
		{
			repository = G.TContainer.Resolve<IAccountRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AccountService()
		{
			Dispose(false);
		}
		#endregion
	}
}
