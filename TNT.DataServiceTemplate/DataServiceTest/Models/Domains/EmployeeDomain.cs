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
	public partial class EmployeeDomain : BaseDomain<Models.Employee, EmployeeViewModel, int, IEmployeeService>
	{
		public EmployeeDomain() : base()
		{
		}
		public EmployeeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
