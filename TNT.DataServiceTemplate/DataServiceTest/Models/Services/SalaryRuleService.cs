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
	public partial interface ISalaryRuleService : IBaseService<SalaryRule, SalaryRuleViewModel, int>
	{
	}
	
	public partial class SalaryRuleService : BaseService<SalaryRule, SalaryRuleViewModel, int>, ISalaryRuleService
	{
		public SalaryRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISalaryRuleRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public SalaryRuleService()
		{
			repository = G.TContainer.Resolve<ISalaryRuleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SalaryRuleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
