using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class Segment : BaseEntity<SegmentViewModel>
	{
		public override SegmentViewModel ToViewModel()
		{
			return new SegmentViewModel(this);
		}
		
	}
}
