using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace Promoter.DataService.Models.Services
{
	public partial interface IVoucherService : IBaseService<Voucher, int>
	{
	}
	
	public partial class VoucherService : BaseService<Voucher, int>, IVoucherService
	{
		public VoucherService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVoucherRepository>(uow);
		}
		
		public VoucherService(DbContext context)
		{
			repository = G.TContainer.Resolve<IVoucherRepository>(context);
		}
		
	}
}
