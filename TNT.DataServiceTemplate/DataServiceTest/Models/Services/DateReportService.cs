using System;
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
	public partial interface IDateReportService : IBaseService<DateReport, DateReportViewModel, int>
	{
	}
	
	public partial class DateReportService : BaseService<DateReport, DateReportViewModel, int>, IDateReportService
	{
		public DateReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateReportRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DateReportService()
		{
			repository = G.TContainer.Resolve<IDateReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
