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
	public partial interface ISalaryHourService : IBaseService<SalaryHour, SalaryHourViewModel, int>
	{
	}
	
	public partial class SalaryHourService : BaseService<SalaryHour, SalaryHourViewModel, int>, ISalaryHourService
	{
		public SalaryHourService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISalaryHourRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public SalaryHourService()
		{
			repository = G.TContainer.Resolve<ISalaryHourRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SalaryHourService()
		{
			Dispose(false);
		}
		#endregion
	}
}
