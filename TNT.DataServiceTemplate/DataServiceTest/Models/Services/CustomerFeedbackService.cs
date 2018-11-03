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
	public partial interface ICustomerFeedbackService : IBaseService<CustomerFeedback, CustomerFeedbackViewModel, CustomerFeedbackPK>
	{
	}
	
	public partial class CustomerFeedbackService : BaseService<CustomerFeedback, CustomerFeedbackViewModel, CustomerFeedbackPK>, ICustomerFeedbackService
	{
		public CustomerFeedbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerFeedbackRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CustomerFeedbackService()
		{
			repository = G.TContainer.Resolve<ICustomerFeedbackRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerFeedbackService()
		{
			Dispose(false);
		}
		#endregion
	}
}
