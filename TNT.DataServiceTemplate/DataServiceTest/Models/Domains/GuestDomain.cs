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
	public partial class GuestDomain : BaseDomain<Models.Guest, GuestViewModel, int, IGuestService>
	{
		public GuestDomain() : base()
		{
		}
		public GuestDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
