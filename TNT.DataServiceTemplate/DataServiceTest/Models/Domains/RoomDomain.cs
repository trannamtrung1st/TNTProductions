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
	public partial class RoomDomain : BaseDomain<Models.Room, RoomViewModel, int, IRoomService>
	{
		public RoomDomain() : base()
		{
		}
		public RoomDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
