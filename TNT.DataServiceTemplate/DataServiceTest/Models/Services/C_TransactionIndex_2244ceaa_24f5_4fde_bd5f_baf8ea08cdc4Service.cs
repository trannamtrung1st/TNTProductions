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
	public partial interface IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : IBaseService<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel, System.Guid>
	{
	}
	
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service : BaseService<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4ViewModel, System.Guid>, IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service
	{
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service()
		{
			repository = G.TContainer.Resolve<IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Service()
		{
			Dispose(false);
		}
		#endregion
	}
}
