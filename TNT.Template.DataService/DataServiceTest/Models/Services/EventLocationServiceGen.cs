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
	public partial interface IEventLocationService : IBaseService<EventLocation, int>
	{
	}
	
	public partial class EventLocationService : BaseService<EventLocation, int>, IEventLocationService
	{
		public EventLocationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEventLocationRepository>(uow);
		}
		
		public EventLocationService(DbContext context)
		{
			repository = G.TContainer.Resolve<IEventLocationRepository>(context);
		}
		
	}
}
