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
	public partial class NotificationDomain : BaseDomain<Models.Notification, NotificationViewModel, int, INotificationService>
	{
		public NotificationDomain() : base()
		{
		}
		public NotificationDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
