using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class CustomerSegmentPK
	{
		public int CustomerIID { get; set; }
		public int SegmentIID { get; set; }
	}
	
	public partial class CustomerSegment : BaseEntity
	{
	}
}
