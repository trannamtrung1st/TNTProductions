using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class RoomFloor : BaseEntity<RoomFloorViewModel>
	{
		public override RoomFloorViewModel ToViewModel()
		{
			return new RoomFloorViewModel(this);
		}
		
	}
}
