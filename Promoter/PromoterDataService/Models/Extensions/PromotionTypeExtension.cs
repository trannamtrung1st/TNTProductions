using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class PromotionTypePK
	{
		public int PromotionDetailID { get; set; }
		public int Type { get; set; }
	}
	
	public partial class PromotionType : BaseEntity
	{
	}
}
