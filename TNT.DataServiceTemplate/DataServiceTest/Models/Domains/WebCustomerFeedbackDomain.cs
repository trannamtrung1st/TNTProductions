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
	public partial class WebCustomerFeedbackDomain : BaseDomain<Models.WebCustomerFeedback, WebCustomerFeedbackViewModel, int, IWebCustomerFeedbackService>
	{
		public WebCustomerFeedbackDomain() : base()
		{
		}
		public WebCustomerFeedbackDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
