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
	public partial class EmployeeFingerDomain : BaseDomain<Models.EmployeeFinger, EmployeeFingerViewModel, int, IEmployeeFingerService>
	{
		public EmployeeFingerDomain() : base()
		{
		}
		public EmployeeFingerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
