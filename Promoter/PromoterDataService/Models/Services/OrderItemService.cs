﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IOrderItemService : IBaseService<OrderItem, OrderItemViewModel, int>
	{
	}
	
	public partial class OrderItemService : BaseService<OrderItem, OrderItemViewModel, int>, IOrderItemService
	{
		public OrderItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderItemRepository>(uow);
		}
		
	}
}
