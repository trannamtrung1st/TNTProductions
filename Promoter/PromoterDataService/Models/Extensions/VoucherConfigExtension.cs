using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class VoucherConfig : BaseEntity<VoucherConfigViewModel>
	{
		public override VoucherConfigViewModel ToViewModel()
		{
			return new VoucherConfigViewModel(this);
		}
		
	}
}
