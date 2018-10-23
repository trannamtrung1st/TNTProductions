using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class Coupon : BaseEntity<CouponViewModel>
	{
		public override CouponViewModel ToViewModel()
		{
			return new CouponViewModel(this);
		}
		
	}
}
