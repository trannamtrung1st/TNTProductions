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
	public partial interface IEventService : IBaseService<Event, EventViewModel, int>
	{
	}
	
	public partial class EventService : BaseService<Event, EventViewModel, int>, IEventService
	{
		public EventService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEventRepository>(uow);
		}
		
	}
}
