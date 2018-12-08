using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : IBaseService<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, System.Guid>
	{
	}
	
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : BaseService<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, System.Guid>, IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service
	{
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>(uow);
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service(DbContext context)
		{
			repository = G.TContainer.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>(context);
		}
		
	}
}
