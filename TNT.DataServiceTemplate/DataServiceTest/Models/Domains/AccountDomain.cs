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
	public partial class AccountDomain : BaseDomain<Models.Account, AccountViewModel, int, IAccountService>
	{
		public AccountDomain() : base()
		{
		}
		public AccountDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
