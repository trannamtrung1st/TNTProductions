using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IWebCustomerFeedbackService : IBaseService<WebCustomerFeedback, int>
	{
	}
	
	public partial class WebCustomerFeedbackService : BaseService<WebCustomerFeedback, int>, IWebCustomerFeedbackService
	{
		public WebCustomerFeedbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebCustomerFeedbackRepository>(uow);
		}
		
		public WebCustomerFeedbackService(DbContext context)
		{
			repository = G.TContainer.Resolve<IWebCustomerFeedbackRepository>(context);
		}
		
	}
}
