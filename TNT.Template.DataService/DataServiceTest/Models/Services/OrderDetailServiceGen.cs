using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IOrderDetailService : IBaseService<OrderDetail, int>
	{
	}
	
	public partial class OrderDetailService : BaseService<OrderDetail, int>, IOrderDetailService
	{
		public OrderDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailRepository>(uow);
		}
		
		public OrderDetailService(DbContext context)
		{
			repository = G.TContainer.Resolve<IOrderDetailRepository>(context);
		}
		
	}
}
