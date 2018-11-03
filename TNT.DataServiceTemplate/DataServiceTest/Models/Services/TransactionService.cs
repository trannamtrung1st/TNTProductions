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
	public partial interface ITransactionService : IBaseService<Transaction, TransactionViewModel, int>
	{
	}
	
	public partial class TransactionService : BaseService<Transaction, TransactionViewModel, int>, ITransactionService
	{
		public TransactionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITransactionRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TransactionService()
		{
			repository = G.TContainer.Resolve<ITransactionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TransactionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
