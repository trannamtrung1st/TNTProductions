using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class RoomCategoryPriceGroupMappingPK
	{
		public int CategoryID { get; set; }
		public int PriceGroupID { get; set; }
	}
	
	public partial class RoomCategoryPriceGroupMapping : BaseEntity
	{
	}
}
