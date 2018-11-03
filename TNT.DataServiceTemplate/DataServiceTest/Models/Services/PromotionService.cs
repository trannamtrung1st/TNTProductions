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
	public partial interface IPromotionService : IBaseService<Promotion, PromotionViewModel, int>
	{
	}
	
	public partial class PromotionService : BaseService<Promotion, PromotionViewModel, int>, IPromotionService
	{
		public PromotionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PromotionService()
		{
			repository = G.TContainer.Resolve<IPromotionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
