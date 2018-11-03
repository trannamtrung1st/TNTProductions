using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class GiftDetailPK
	{
		public int ProductIID { get; set; }
		public int PromotionDetailID { get; set; }
	}
	
	public partial class GiftDetail : BaseEntity<GiftDetailViewModel>
	{
		public override GiftDetailViewModel ToViewModel()
		{
			return new GiftDetailViewModel(this);
		}
		
	}
}
