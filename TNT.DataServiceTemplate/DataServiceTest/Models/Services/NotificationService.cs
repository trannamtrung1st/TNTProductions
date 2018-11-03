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
	public partial interface INotificationService : IBaseService<Notification, NotificationViewModel, int>
	{
	}
	
	public partial class NotificationService : BaseService<Notification, NotificationViewModel, int>, INotificationService
	{
		public NotificationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<INotificationRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public NotificationService()
		{
			repository = G.TContainer.Resolve<INotificationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~NotificationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
