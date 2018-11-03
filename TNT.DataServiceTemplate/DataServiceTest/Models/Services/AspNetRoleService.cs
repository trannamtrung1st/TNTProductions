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
	public partial interface IAspNetRoleService : IBaseService<AspNetRole, AspNetRoleViewModel, string>
	{
	}
	
	public partial class AspNetRoleService : BaseService<AspNetRole, AspNetRoleViewModel, string>, IAspNetRoleService
	{
		public AspNetRoleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAspNetRoleRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public AspNetRoleService()
		{
			repository = G.TContainer.Resolve<IAspNetRoleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AspNetRoleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
