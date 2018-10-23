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
