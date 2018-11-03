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
	public partial interface IWardService : IBaseService<Ward, WardViewModel, int>
	{
	}
	
	public partial class WardService : BaseService<Ward, WardViewModel, int>, IWardService
	{
		public WardService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWardRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WardService()
		{
			repository = G.TContainer.Resolve<IWardRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WardService()
		{
			Dispose(false);
		}
		#endregion
	}
}
