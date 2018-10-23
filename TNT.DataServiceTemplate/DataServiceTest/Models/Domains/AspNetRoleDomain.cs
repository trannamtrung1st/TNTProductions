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
	public partial class AspNetRoleDomain : BaseDomain<Models.AspNetRole, AspNetRoleViewModel, string, IAspNetRoleService>
	{
		public AspNetRoleDomain() : base()
		{
		}
		public AspNetRoleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
