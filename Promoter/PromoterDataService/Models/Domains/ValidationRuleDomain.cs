using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class ValidationRuleDomain : BaseDomain<Models.ValidationRule, ValidationRuleViewModel, int, IValidationRuleService>
	{
		public ValidationRuleDomain() : base()
		{
		}
		public ValidationRuleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
