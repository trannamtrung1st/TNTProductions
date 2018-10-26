using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class EventDomain : BaseDomain<Models.Event, EventViewModel, int, IEventService>
	{
		public EventDomain() : base()
		{
		}
		public EventDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
