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
	public partial interface IAspNetUserService : IBaseService<AspNetUser, AspNetUserViewModel, string>
	{
	}
	
	public partial class AspNetUserService : BaseService<AspNetUser, AspNetUserViewModel, string>, IAspNetUserService
	{
		public AspNetUserService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetUserRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AspNetUserService()
		{
			repository = G.TContainer.Resolve<IAspNetUserRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetUserService()
		{
			Dispose(false);
		}
		#endregion
	}
}
