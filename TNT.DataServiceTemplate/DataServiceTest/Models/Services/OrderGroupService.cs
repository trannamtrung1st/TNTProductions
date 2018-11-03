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
	public partial interface IOrderGroupService : IBaseService<OrderGroup, OrderGroupViewModel, int>
	{
	}
	
	public partial class OrderGroupService : BaseService<OrderGroup, OrderGroupViewModel, int>, IOrderGroupService
	{
		public OrderGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderGroupService()
		{
			repository = G.TContainer.Resolve<IOrderGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
