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
	public partial class TransactionDomain : BaseDomain<Models.Transaction, TransactionViewModel, int, ITransactionService>
	{
		public TransactionDomain() : base()
		{
		}
		public TransactionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
