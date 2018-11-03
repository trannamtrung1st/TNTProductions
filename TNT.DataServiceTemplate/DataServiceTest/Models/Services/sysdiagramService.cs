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
	public partial interface IsysdiagramService : IBaseService<sysdiagram, sysdiagramViewModel, int>
	{
	}
	
	public partial class sysdiagramService : BaseService<sysdiagram, sysdiagramViewModel, int>, IsysdiagramService
	{
		public sysdiagramService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IsysdiagramRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public sysdiagramService()
		{
			repository = G.TContainer.Resolve<IsysdiagramRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~sysdiagramService()
		{
			Dispose(false);
		}
		#endregion
	}
}
