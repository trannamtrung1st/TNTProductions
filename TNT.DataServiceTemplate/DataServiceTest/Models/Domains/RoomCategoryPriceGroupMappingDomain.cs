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
	public partial class RoomCategoryPriceGroupMappingDomain : BaseDomain<Models.RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingViewModel, RoomCategoryPriceGroupMappingPK, IRoomCategoryPriceGroupMappingService>
	{
		public RoomCategoryPriceGroupMappingDomain() : base()
		{
		}
		public RoomCategoryPriceGroupMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
