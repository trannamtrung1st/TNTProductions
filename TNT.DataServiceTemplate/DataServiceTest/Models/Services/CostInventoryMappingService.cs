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
	public partial interface ICostInventoryMappingService : IBaseService<CostInventoryMapping, CostInventoryMappingViewModel, CostInventoryMappingPK>
	{
	}
	
	public partial class CostInventoryMappingService : BaseService<CostInventoryMapping, CostInventoryMappingViewModel, CostInventoryMappingPK>, ICostInventoryMappingService
	{
		public CostInventoryMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostInventoryMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CostInventoryMappingService()
		{
			repository = G.TContainer.Resolve<ICostInventoryMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostInventoryMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
