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
	public partial interface IPriceAdditionService : IBaseService<PriceAddition, PriceAdditionViewModel, int>
	{
	}
	
	public partial class PriceAdditionService : BaseService<PriceAddition, PriceAdditionViewModel, int>, IPriceAdditionService
	{
		public PriceAdditionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPriceAdditionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PriceAdditionService()
		{
			repository = G.TContainer.Resolve<IPriceAdditionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PriceAdditionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
