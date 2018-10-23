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
	public partial class AspNetUserLoginDomain : BaseDomain<Models.AspNetUserLogin, AspNetUserLoginViewModel, AspNetUserLoginPK, IAspNetUserLoginService>
	{
		public AspNetUserLoginDomain() : base()
		{
		}
		public AspNetUserLoginDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
