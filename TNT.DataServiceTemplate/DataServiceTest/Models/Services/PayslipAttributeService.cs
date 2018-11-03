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
	public partial interface IPayslipAttributeService : IBaseService<PayslipAttribute, PayslipAttributeViewModel, int>
	{
	}
	
	public partial class PayslipAttributeService : BaseService<PayslipAttribute, PayslipAttributeViewModel, int>, IPayslipAttributeService
	{
		public PayslipAttributeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayslipAttributeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PayslipAttributeService()
		{
			repository = G.TContainer.Resolve<IPayslipAttributeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayslipAttributeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
