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
	public partial interface ISystemPartnerMappingService : IBaseService<SystemPartnerMapping, SystemPartnerMappingViewModel, int>
	{
	}
	
	public partial class SystemPartnerMappingService : BaseService<SystemPartnerMapping, SystemPartnerMappingViewModel, int>, ISystemPartnerMappingService
	{
		public SystemPartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISystemPartnerMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public SystemPartnerMappingService()
		{
			repository = G.TContainer.Resolve<ISystemPartnerMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SystemPartnerMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
