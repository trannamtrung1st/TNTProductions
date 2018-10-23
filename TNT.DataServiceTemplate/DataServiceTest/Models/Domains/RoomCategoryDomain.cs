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
	public partial class RoomCategoryDomain : BaseDomain<Models.RoomCategory, RoomCategoryViewModel, int, IRoomCategoryService>
	{
		public RoomCategoryDomain() : base()
		{
		}
		public RoomCategoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
