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
	public partial interface IOrderDetailService : IBaseService<OrderDetail, OrderDetailViewModel, int>
	{
	}
	
	public partial class OrderDetailService : BaseService<OrderDetail, OrderDetailViewModel, int>, IOrderDetailService
	{
		public OrderDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderDetailService()
		{
			repository = G.TContainer.Resolve<IOrderDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
