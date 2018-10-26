using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class SegmentDomain : BaseDomain<Models.Segment, SegmentViewModel, int, ISegmentService>
	{
		public SegmentDomain() : base()
		{
		}
		public SegmentDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
