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
	public partial class EventLocationDomain : BaseDomain<Models.EventLocation, EventLocationViewModel, int, IEventLocationService>
	{
		public EventLocationDomain() : base()
		{
		}
		public EventLocationDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
