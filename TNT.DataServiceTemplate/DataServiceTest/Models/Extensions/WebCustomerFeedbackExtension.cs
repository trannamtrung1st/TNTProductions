using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class WebCustomerFeedback : BaseEntity<WebCustomerFeedbackViewModel>
	{
		public override WebCustomerFeedbackViewModel ToViewModel()
		{
			return new WebCustomerFeedbackViewModel(this);
		}
		
	}
}
