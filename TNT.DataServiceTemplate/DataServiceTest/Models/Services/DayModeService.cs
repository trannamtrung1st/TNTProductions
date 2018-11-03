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
	public partial interface IDayModeService : IBaseService<DayMode, DayModeViewModel, int>
	{
	}
	
	public partial class DayModeService : BaseService<DayMode, DayModeViewModel, int>, IDayModeService
	{
		public DayModeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDayModeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DayModeService()
		{
			repository = G.TContainer.Resolve<IDayModeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DayModeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
