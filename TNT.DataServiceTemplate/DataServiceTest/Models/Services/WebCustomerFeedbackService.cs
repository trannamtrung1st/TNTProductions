using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IWebCustomerFeedbackService : IBaseService<WebCustomerFeedback, WebCustomerFeedbackViewModel, int>
	{
	}
	
	public partial class WebCustomerFeedbackService : BaseService<WebCustomerFeedback, WebCustomerFeedbackViewModel, int>, IWebCustomerFeedbackService
	{
		public WebCustomerFeedbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebCustomerFeedbackRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public WebCustomerFeedbackService()
		{
			repository = G.TContainer.Resolve<IWebCustomerFeedbackRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebCustomerFeedbackService()
		{
			Dispose(false);
		}
		#endregion
	}
}
