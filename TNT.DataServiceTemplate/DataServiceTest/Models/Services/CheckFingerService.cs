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
	public partial interface ICheckFingerService : IBaseService<CheckFinger, CheckFingerViewModel, int>
	{
	}
	
	public partial class CheckFingerService : BaseService<CheckFinger, CheckFingerViewModel, int>, ICheckFingerService
	{
		public CheckFingerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICheckFingerRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CheckFingerService()
		{
			repository = G.TContainer.Resolve<ICheckFingerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CheckFingerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
