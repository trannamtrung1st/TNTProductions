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
	public partial interface ICostService : IBaseService<Cost, CostViewModel, int>
	{
	}
	
	public partial class CostService : BaseService<Cost, CostViewModel, int>, ICostService
	{
		public CostService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CostService()
		{
			repository = G.TContainer.Resolve<ICostRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostService()
		{
			Dispose(false);
		}
		#endregion
	}
}
