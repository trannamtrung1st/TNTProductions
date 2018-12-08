﻿using System;
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
	public partial interface IOrderDetailPromotionMappingService : IBaseService<OrderDetailPromotionMapping, int>
	{
	}
	
	public partial class OrderDetailPromotionMappingService : BaseService<OrderDetailPromotionMapping, int>, IOrderDetailPromotionMappingService
	{
		public OrderDetailPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailPromotionMappingRepository>(uow);
		}
		
		public OrderDetailPromotionMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<IOrderDetailPromotionMappingRepository>(context);
		}
		
	}
}
