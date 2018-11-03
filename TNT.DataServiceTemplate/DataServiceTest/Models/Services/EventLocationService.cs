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
	public partial interface IEventLocationService : IBaseService<EventLocation, EventLocationViewModel, int>
	{
	}
	
	public partial class EventLocationService : BaseService<EventLocation, EventLocationViewModel, int>, IEventLocationService
	{
		public EventLocationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEventLocationRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public EventLocationService()
		{
			repository = G.TContainer.Resolve<IEventLocationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EventLocationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
