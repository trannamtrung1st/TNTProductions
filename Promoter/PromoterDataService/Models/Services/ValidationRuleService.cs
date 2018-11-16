using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IValidationRuleService : IBaseService<ValidationRule, int>
	{
	}
	
	public partial class ValidationRuleService : BaseService<ValidationRule, int>, IValidationRuleService
	{
		public ValidationRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IValidationRuleRepository>(uow);
		}
		
	}
}
