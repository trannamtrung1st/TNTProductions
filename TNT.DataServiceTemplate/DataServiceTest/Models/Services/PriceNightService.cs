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
	public partial interface IPriceNightService : IBaseService<PriceNight, PriceNightViewModel, int>
	{
	}
	
	public partial class PriceNightService : BaseService<PriceNight, PriceNightViewModel, int>, IPriceNightService
	{
		public PriceNightService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceNightRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PriceNightService()
		{
			repository = G.TContainer.Resolve<IPriceNightRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceNightService()
		{
			Dispose(false);
		}
		#endregion
	}
}
