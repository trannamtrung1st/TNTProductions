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
	public partial interface IOrderGroupService : IBaseService<OrderGroup, int>
	{
	}
	
	public partial class OrderGroupService : BaseService<OrderGroup, int>, IOrderGroupService
	{
		public OrderGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderGroupRepository>(uow);
		}
		
		public OrderGroupService(DbContext context)
		{
			repository = G.TContainer.Resolve<IOrderGroupRepository>(context);
		}
		
	}
}
