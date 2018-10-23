using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class ProductItemCompositionMappingPK
	{
		public int ProducID { get; set; }
		public int ItemID { get; set; }
	}
	
	public partial class ProductItemCompositionMapping : BaseEntity<ProductItemCompositionMappingViewModel>
	{
		public override ProductItemCompositionMappingViewModel ToViewModel()
		{
			return new ProductItemCompositionMappingViewModel(this);
		}
		
	}
}
