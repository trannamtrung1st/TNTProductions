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
	public partial class RoomFloorDomain : BaseDomain<Models.RoomFloor, RoomFloorViewModel, int, IRoomFloorService>
	{
		public RoomFloorDomain() : base()
		{
		}
		public RoomFloorDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
