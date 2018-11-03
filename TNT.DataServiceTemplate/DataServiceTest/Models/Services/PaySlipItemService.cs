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
	public partial interface IPaySlipItemService : IBaseService<PaySlipItem, PaySlipItemViewModel, int>
	{
	}
	
	public partial class PaySlipItemService : BaseService<PaySlipItem, PaySlipItemViewModel, int>, IPaySlipItemService
	{
		public PaySlipItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PaySlipItemService()
		{
			repository = G.TContainer.Resolve<IPaySlipItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
