using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Global;

namespace PromoterDataService.Models
{
	public partial class Product : BaseEntity<ProductViewModel>
	{
		public override ProductViewModel ToViewModel()
		{
			return new ProductViewModel(this);
		}
		
	}
}
