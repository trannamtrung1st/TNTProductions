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
	public partial class AspNetUserDomain : BaseDomain<Models.AspNetUser, AspNetUserViewModel, string, IAspNetUserService>
	{
		public AspNetUserDomain() : base()
		{
		}
		public AspNetUserDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
