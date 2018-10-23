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
	public partial class SalaryHourDomain : BaseDomain<Models.SalaryHour, SalaryHourViewModel, int, ISalaryHourService>
	{
		public SalaryHourDomain() : base()
		{
		}
		public SalaryHourDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
