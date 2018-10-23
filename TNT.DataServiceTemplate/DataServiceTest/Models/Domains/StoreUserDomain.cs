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
	public partial class StoreUserDomain : BaseDomain<Models.StoreUser, StoreUserViewModel, StoreUserPK, IStoreUserService>
	{
		public StoreUserDomain() : base()
		{
		}
		public StoreUserDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
