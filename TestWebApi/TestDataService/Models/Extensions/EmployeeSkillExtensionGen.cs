using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.ViewModels;
using TestDataService.Global;

namespace TestDataService.Models
{
	public partial class EmployeeSkillPK
	{
		public string EmpCode { get; set; }
		public int SkillId { get; set; }
	}
	
	public partial class EmployeeSkill : BaseEntity
	{
	}
}
