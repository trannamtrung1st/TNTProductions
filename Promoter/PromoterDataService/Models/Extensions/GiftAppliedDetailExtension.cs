using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class GiftAppliedDetailPK
	{
		public int PromotionAppliedDetailID { get; set; }
		public int ProductIID { get; set; }
	}
	
	public partial class GiftAppliedDetail : BaseEntity
	{
	}
}
