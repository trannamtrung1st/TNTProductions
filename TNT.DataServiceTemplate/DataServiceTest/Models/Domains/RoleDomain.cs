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
	public partial class RoleDomain : BaseDomain<Models.Role, RoleViewModel, System.Guid, IRoleService>
	{
		public RoleDomain() : base()
		{
		}
		public RoleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
