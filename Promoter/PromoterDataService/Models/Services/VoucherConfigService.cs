﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IVoucherConfigService : IBaseService<VoucherConfig, int>
	{
	}
	
	public partial class VoucherConfigService : BaseService<VoucherConfig, int>, IVoucherConfigService
	{
		public VoucherConfigService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IVoucherConfigRepository>(uow);
		}
		
	}
}
