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
	public partial interface IStoreDomainService : IBaseService<StoreDomain, StoreDomainViewModel, int>
	{
	}
	
	public partial class StoreDomainService : BaseService<StoreDomain, StoreDomainViewModel, int>, IStoreDomainService
	{
		public StoreDomainService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreDomainRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public StoreDomainService()
		{
			repository = G.TContainer.Resolve<IStoreDomainRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreDomainService()
		{
			Dispose(false);
		}
		#endregion
	}
}
