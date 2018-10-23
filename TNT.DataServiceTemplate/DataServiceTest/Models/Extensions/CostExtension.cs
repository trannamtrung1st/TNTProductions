using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class Cost : BaseEntity<CostViewModel>
	{
		public override CostViewModel ToViewModel()
		{
			return new CostViewModel(this);
		}
		
	}
}
