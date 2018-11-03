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
	public partial interface IVATOrderService : IBaseService<VATOrder, VATOrderViewModel, int>
	{
	}
	
	public partial class VATOrderService : BaseService<VATOrder, VATOrderViewModel, int>, IVATOrderService
	{
		public VATOrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVATOrderRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public VATOrderService()
		{
			repository = G.TContainer.Resolve<IVATOrderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~VATOrderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
