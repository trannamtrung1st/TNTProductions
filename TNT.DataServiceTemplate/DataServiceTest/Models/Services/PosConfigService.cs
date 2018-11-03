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
	public partial interface IPosConfigService : IBaseService<PosConfig, PosConfigViewModel, int>
	{
	}
	
	public partial class PosConfigService : BaseService<PosConfig, PosConfigViewModel, int>, IPosConfigService
	{
		public PosConfigService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosConfigRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PosConfigService()
		{
			repository = G.TContainer.Resolve<IPosConfigRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosConfigService()
		{
			Dispose(false);
		}
		#endregion
	}
}
