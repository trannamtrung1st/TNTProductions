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
	public partial interface ICostService : IBaseService<Cost, int>
	{
	}
	
	public partial class CostService : BaseService<Cost, int>, ICostService
	{
		public CostService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostRepository>(uow);
		}
		
		public CostService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICostRepository>(context);
		}
		
	}
}
