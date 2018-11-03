﻿using System;
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
	public partial interface IOrderService : IBaseService<Order, OrderViewModel, int>
	{
	}
	
	public partial class OrderService : BaseService<Order, OrderViewModel, int>, IOrderService
	{
		public OrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public OrderService()
		{
			repository = G.TContainer.Resolve<IOrderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
