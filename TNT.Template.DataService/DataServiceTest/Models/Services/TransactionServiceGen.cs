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
	public partial interface ITransactionService : IBaseService<Transaction, int>
	{
	}
	
	public partial class TransactionService : BaseService<Transaction, int>, ITransactionService
	{
		public TransactionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITransactionRepository>(uow);
		}
		
		public TransactionService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITransactionRepository>(context);
		}
		
	}
}
