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
	public partial interface IAspNetUserLoginService : IBaseService<AspNetUserLogin, AspNetUserLoginViewModel, AspNetUserLoginPK>
	{
	}
	
	public partial class AspNetUserLoginService : BaseService<AspNetUserLogin, AspNetUserLoginViewModel, AspNetUserLoginPK>, IAspNetUserLoginService
	{
		public AspNetUserLoginService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserLoginRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AspNetUserLoginService()
		{
			repository = G.TContainer.Resolve<IAspNetUserLoginRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserLoginService()
		{
			Dispose(false);
		}
		#endregion
	}
}
