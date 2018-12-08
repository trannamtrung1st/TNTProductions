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
	public partial interface IPayslipAttributeService : IBaseService<PayslipAttribute, int>
	{
	}
	
	public partial class PayslipAttributeService : BaseService<PayslipAttribute, int>, IPayslipAttributeService
	{
		public PayslipAttributeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayslipAttributeRepository>(uow);
		}
		
		public PayslipAttributeService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPayslipAttributeRepository>(context);
		}
		
	}
}
