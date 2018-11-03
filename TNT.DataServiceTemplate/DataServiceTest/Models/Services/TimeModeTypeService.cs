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
	public partial interface ITimeModeTypeService : IBaseService<TimeModeType, TimeModeTypeViewModel, int>
	{
	}
	
	public partial class TimeModeTypeService : BaseService<TimeModeType, TimeModeTypeViewModel, int>, ITimeModeTypeService
	{
		public TimeModeTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITimeModeTypeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TimeModeTypeService()
		{
			repository = G.TContainer.Resolve<ITimeModeTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TimeModeTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
