using System;
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
	public partial interface IPaySlipTemplateService : IBaseService<PaySlipTemplate, int>
	{
	}
	
	public partial class PaySlipTemplateService : BaseService<PaySlipTemplate, int>, IPaySlipTemplateService
	{
		public PaySlipTemplateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipTemplateRepository>(uow);
		}
		
		public PaySlipTemplateService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPaySlipTemplateRepository>(context);
		}
		
	}
}
