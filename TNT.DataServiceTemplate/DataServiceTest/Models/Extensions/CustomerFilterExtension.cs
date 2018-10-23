using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class CustomerFilter : BaseEntity<CustomerFilterViewModel>
	{
		public override CustomerFilterViewModel ToViewModel()
		{
			return new CustomerFilterViewModel(this);
		}
		
	}
}
