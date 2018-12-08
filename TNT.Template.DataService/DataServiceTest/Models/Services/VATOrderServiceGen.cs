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
	public partial interface IVATOrderService : IBaseService<VATOrder, int>
	{
	}
	
	public partial class VATOrderService : BaseService<VATOrder, int>, IVATOrderService
	{
		public VATOrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVATOrderRepository>(uow);
		}
		
		public VATOrderService(DbContext context)
		{
			repository = G.TContainer.Resolve<IVATOrderRepository>(context);
		}
		
	}
}
