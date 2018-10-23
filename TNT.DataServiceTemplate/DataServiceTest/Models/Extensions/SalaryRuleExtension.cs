using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class SalaryRule : BaseEntity<SalaryRuleViewModel>
	{
		public override SalaryRuleViewModel ToViewModel()
		{
			return new SalaryRuleViewModel(this);
		}
		
	}
}
