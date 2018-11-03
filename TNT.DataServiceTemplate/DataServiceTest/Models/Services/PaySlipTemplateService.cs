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
	public partial interface IPaySlipTemplateService : IBaseService<PaySlipTemplate, PaySlipTemplateViewModel, int>
	{
	}
	
	public partial class PaySlipTemplateService : BaseService<PaySlipTemplate, PaySlipTemplateViewModel, int>, IPaySlipTemplateService
	{
		public PaySlipTemplateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipTemplateRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PaySlipTemplateService()
		{
			repository = G.TContainer.Resolve<IPaySlipTemplateRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipTemplateService()
		{
			Dispose(false);
		}
		#endregion
	}
}
