using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class OrderFeeItem : BaseEntity<OrderFeeItemViewModel>
	{
		public override OrderFeeItemViewModel ToViewModel()
		{
			return new OrderFeeItemViewModel(this);
		}
		
	}
}
