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
	public partial interface IProviderProductItemMappingService : IBaseService<ProviderProductItemMapping, ProviderProductItemMappingViewModel, int>
	{
	}
	
	public partial class ProviderProductItemMappingService : BaseService<ProviderProductItemMapping, ProviderProductItemMappingViewModel, int>, IProviderProductItemMappingService
	{
		public ProviderProductItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProviderProductItemMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProviderProductItemMappingService()
		{
			repository = G.TContainer.Resolve<IProviderProductItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProviderProductItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
