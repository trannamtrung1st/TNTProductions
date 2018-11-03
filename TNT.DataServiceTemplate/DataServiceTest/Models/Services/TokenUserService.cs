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
	public partial interface ITokenUserService : IBaseService<TokenUser, TokenUserViewModel, int>
	{
	}
	
	public partial class TokenUserService : BaseService<TokenUser, TokenUserViewModel, int>, ITokenUserService
	{
		public TokenUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITokenUserRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TokenUserService()
		{
			repository = G.TContainer.Resolve<ITokenUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TokenUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
