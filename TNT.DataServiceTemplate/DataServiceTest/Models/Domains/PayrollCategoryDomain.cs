using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class PayrollCategoryDomain : BaseDomain<Models.PayrollCategory, PayrollCategoryViewModel, int, IPayrollCategoryService>
	{
		public PayrollCategoryDomain() : base()
		{
		}
		public PayrollCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
