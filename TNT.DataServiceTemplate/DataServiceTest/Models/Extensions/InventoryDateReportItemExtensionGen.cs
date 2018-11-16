using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class InventoryDateReportItemPK
	{
		public int ItemID { get; set; }
		public int ReportID { get; set; }
	}
	
	public partial class InventoryDateReportItem : BaseEntity
	{
	}
}
