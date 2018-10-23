using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class Employee : BaseEntity<EmployeeViewModel>
	{
		public override EmployeeViewModel ToViewModel()
		{
			return new EmployeeViewModel(this);
		}
		
	}
}
