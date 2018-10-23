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
	public partial class TokenUserDomain : BaseDomain<Models.TokenUser, TokenUserViewModel, int, ITokenUserService>
	{
		public TokenUserDomain() : base()
		{
		}
		public TokenUserDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
