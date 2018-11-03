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
	public partial interface IPayslipAttributeMappingService : IBaseService<PayslipAttributeMapping, PayslipAttributeMappingViewModel, int>
	{
	}
	
	public partial class PayslipAttributeMappingService : BaseService<PayslipAttributeMapping, PayslipAttributeMappingViewModel, int>, IPayslipAttributeMappingService
	{
		public PayslipAttributeMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayslipAttributeMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PayslipAttributeMappingService()
		{
			repository = G.TContainer.Resolve<IPayslipAttributeMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayslipAttributeMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
