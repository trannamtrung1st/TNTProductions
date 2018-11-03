using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IVoucherService : IBaseService<Voucher, VoucherViewModel, int>
	{
	}
	
	public partial class VoucherService : BaseService<Voucher, VoucherViewModel, int>, IVoucherService
	{
		public VoucherService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVoucherRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public VoucherService()
		{
			repository = G.TContainer.Resolve<IVoucherRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~VoucherService()
		{
			Dispose(false);
		}
		#endregion
	}
}
