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
	public partial interface IGuestService : IBaseService<Guest, GuestViewModel, int>
	{
	}
	
	public partial class GuestService : BaseService<Guest, GuestViewModel, int>, IGuestService
	{
		public GuestService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGuestRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public GuestService()
		{
			repository = G.TContainer.Resolve<IGuestRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~GuestService()
		{
			Dispose(false);
		}
		#endregion
	}
}
