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
	public partial class UserDomain : BaseDomain<Models.User, UserViewModel, System.Guid, IUserService>
	{
		public UserDomain() : base()
		{
		}
		public UserDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
