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
	public partial interface IDeliveryInformationService : IBaseService<DeliveryInformation, int>
	{
	}
	
	public partial class DeliveryInformationService : BaseService<DeliveryInformation, int>, IDeliveryInformationService
	{
		public DeliveryInformationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeliveryInformationRepository>(uow);
		}
		
		public DeliveryInformationService(DbContext context)
		{
			repository = G.TContainer.Resolve<IDeliveryInformationRepository>(context);
		}
		
	}
}
