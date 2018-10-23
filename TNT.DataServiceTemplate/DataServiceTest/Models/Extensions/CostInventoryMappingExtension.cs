using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class CostInventoryMappingPK
	{
		public int CostID { get; set; }
		public int ReceiptID { get; set; }
	}
	
	public partial class CostInventoryMapping : BaseEntity<CostInventoryMappingViewModel>
	{
		public override CostInventoryMappingViewModel ToViewModel()
		{
			return new CostInventoryMappingViewModel(this);
		}
		
	}
}
