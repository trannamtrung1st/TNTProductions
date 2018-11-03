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
	public partial interface IPartnerMappingService : IBaseService<PartnerMapping, PartnerMappingViewModel, int>
	{
	}
	
	public partial class PartnerMappingService : BaseService<PartnerMapping, PartnerMappingViewModel, int>, IPartnerMappingService
	{
		public PartnerMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPartnerMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PartnerMappingService()
		{
			repository = G.TContainer.Resolve<IPartnerMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PartnerMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
