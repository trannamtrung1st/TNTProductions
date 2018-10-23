using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class CouponDomain : BaseDomain<Models.Coupon, CouponViewModel, int, ICouponService>
	{
		public CouponDomain() : base()
		{
		}
		public CouponDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
