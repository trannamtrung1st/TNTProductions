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
	public partial interface IPriceGroupService : IBaseService<PriceGroup, PriceGroupViewModel, int>
	{
	}
	
	public partial class PriceGroupService : BaseService<PriceGroup, PriceGroupViewModel, int>, IPriceGroupService
	{
		public PriceGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PriceGroupService()
		{
			repository = G.TContainer.Resolve<IPriceGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
