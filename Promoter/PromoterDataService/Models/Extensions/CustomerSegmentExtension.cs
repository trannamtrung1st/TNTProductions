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
		public int CustomerId { get; set; }
		public int SegmentId { get; set; }
	}
	
	public partial class CustomerSegment : BaseEntity<CustomerSegmentViewModel>
	{
		public override CustomerSegmentViewModel ToViewModel()
		{
			return new CustomerSegmentViewModel(this);
		}
		
	}
}
