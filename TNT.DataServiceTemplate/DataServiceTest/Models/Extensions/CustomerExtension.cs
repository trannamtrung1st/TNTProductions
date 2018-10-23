using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class Customer : BaseEntity<CustomerViewModel>
	{
		public override CustomerViewModel ToViewModel()
		{
			return new CustomerViewModel(this);
		}
		
	}
}
