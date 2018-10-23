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
	public partial class CouponProviderDomain : BaseDomain<Models.CouponProvider, CouponProviderViewModel, int, ICouponProviderService>
	{
		public CouponProviderDomain() : base()
		{
		}
		public CouponProviderDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
