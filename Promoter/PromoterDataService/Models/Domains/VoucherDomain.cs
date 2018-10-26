using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
{
	public partial class VoucherDomain : BaseDomain<Models.Voucher, VoucherViewModel, int, IVoucherService>
	{
		public VoucherDomain() : base()
		{
		}
		public VoucherDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
