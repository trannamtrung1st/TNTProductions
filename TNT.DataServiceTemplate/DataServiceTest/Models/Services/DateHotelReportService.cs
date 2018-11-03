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
	public partial interface IDateHotelReportService : IBaseService<DateHotelReport, DateHotelReportViewModel, int>
	{
	}
	
	public partial class DateHotelReportService : BaseService<DateHotelReport, DateHotelReportViewModel, int>, IDateHotelReportService
	{
		public DateHotelReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateHotelReportRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DateHotelReportService()
		{
			repository = G.TContainer.Resolve<IDateHotelReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateHotelReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
